using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;


public class Player_2 : MonoBehaviour
{
    public Rigidbody rb; //Karakterin Rigidbody Componenti.
    public GameObject CameraHolder; //Karakterin �ocugu olan kamera tutucu objesi.
    public float speed; // Karakterin hareket h�z�
    public Animator animator; //Karakterin animator kontrol�
    public float walkSpeed = 5f; //Karakterin y�r�me h�z�
    public float sprintSpeed = 10f; //Karakterin ko�ma h�z�
    public Animator Character_Animator; //Karakterin animator kontrol�
    private bool Run = false; //Player Input componentindeki Run actionu i�in
    private Vector2 input;
    public float sensitivity; // Kamera duyarl�l���.
    public float MaxForce; // Makisumum kuvvet.
    public float JumpForce; // z�plama kuvveti.
    private Vector2 move, look; // Hareket ve bak�� y�nlerini tutan vekt�rler.
    private float LookRotation; //Kamera bak�� a��s�n� tutan de�i�ken.
    public bool is_Grounded;//Karakter zeminde mi?

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();// Hareket girdisini al�r ve 'move' vekt�r�ne atar.
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>(); //bak�� girdisini al�r ve 'look' vekt�r�ne atar.
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        Jump();
    }
    public void Onrun(InputValue value) // Player Input comp'daki Run'dan gelen de�eri al�r
    {
        Sprint();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        
    }
    void Sprint() //Karakterin ko�ma aksiyonu i�in
    {
        float speed = Run ? sprintSpeed : walkSpeed;// Hareket h�z�n� ko�ma durumuna g�re ayarla
        Vector3 move = new Vector3(input.x, 0, input.y) * speed;// Hareket y�n�n� ve h�z�n� belirle
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);// Hareketi Rigidbody bile�enine uygula
    }
    void Jump()
    {
        Vector3 JumpForces = Vector3.zero;
        if (is_Grounded) //E�er karakter zemindeyse,
        {
            JumpForces = Vector3.up * JumpForce; 
        }
        rb.AddForce(JumpForces, ForceMode.VelocityChange);
    }
    void Move()
    {
        Vector3 CurrentVelocity = rb.velocity; // Karakterin mevcut h�z�n� al�r.
        Vector3 TargetVelocity = new Vector3(move.x, 0, move.y); // Hareket girdisinden hedef h�z� olu�turur.
        TargetVelocity *= speed; // Hedef h�z� karakterin hareket h�z� ile �arpar.
        TargetVelocity = transform.TransformDirection(TargetVelocity); // Hedef h�z� d�nya koordinatlar�na d�n��t�r�r.
        Vector3 VelocityChange = (TargetVelocity - CurrentVelocity);// Mevcut h�z ile hedef h�z aras�ndaki fark� hesaplar.
        VelocityChange = new Vector3(VelocityChange.x,0,VelocityChange.z); //karakterin direkt olarak d��mesini sa�lad�m.
        Vector3.ClampMagnitude(VelocityChange, MaxForce);// H�z de�i�imini maksimum kuvvetle s�n�rlar.
        rb.AddForce(VelocityChange, ForceMode.VelocityChange);// Rigidbody'ye h�z de�i�imini uygular.
    }
    
    void Look()
    {
        //D�n�� i�in
        transform.Rotate(Vector3.up * look.x * sensitivity);

        //Bak�� i�in
        LookRotation += (-look.y * sensitivity);
        LookRotation = Mathf.Clamp(LookRotation, -90, 90); //Kameran�n bak�� a��lar�n� s�n�rlamak i�in.
        CameraHolder.transform.eulerAngles = new Vector3(LookRotation, CameraHolder.transform.eulerAngles.y, CameraHolder.transform.eulerAngles.z);

    }
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        Look();
    }
    public void SetGrounded(bool state) 
    {
        is_Grounded=state; //is_Grounded de�i�kenini State'e e�itle 
    }
    
}