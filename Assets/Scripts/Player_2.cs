using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using static UnityEngine.Rendering.DebugUI;


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
    public bool is_Grounded_2;//Karakter zeminde mi?
    public bool isJumping; //Karakter z�plad� m�?
    public bool isRunning; //Karakter ko�uyor mu?

    void Start()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

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
    public void OnRun(InputAction.CallbackContext context) // Player Input comp'daki Run'dan gelen de�eri al�r
    {
        if (context.performed)
        {
            isRunning = true; // Ko�may� ba�lat
        }
        else if (context.canceled)
        {
            isRunning = false; // Ko�may� durdur
        }

        Sprint(); // Ko�ma fonksiyonunu �a��r
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
        float currentSpeed = isRunning ? sprintSpeed : walkSpeed; // Ko�ma h�z�n� kontrol et
        Vector3 targetVelocity = new Vector3(move.x, 0, move.y) * currentSpeed; // Hedef h�z� belirle
        targetVelocity = transform.TransformDirection(targetVelocity); // Hedef h�z� d�nya koordinatlar�na �evir

        Vector3 velocityChange = targetVelocity - rb.velocity; // H�z de�i�imini hesapla
        velocityChange.y = 0; // Y ekseninde herhangi bir h�z de�i�ikli�i yapma
        velocityChange = Vector3.ClampMagnitude(velocityChange, MaxForce); // H�z de�i�imini maksimum kuvvetle s�n�rla

        rb.AddForce(velocityChange, ForceMode.VelocityChange); // Rigidbody'ye h�z de�i�imini uygula

        animator.SetBool("isRunning", isRunning); // Animator'a ko�ma durumunu bildir
    }
    void Jump()
    {
        Vector3 JumpForces = Vector3.zero;
        if (is_Grounded_2) //E�er karakter zemindeyse,
        {
            JumpForces = Vector3.up * JumpForce;
            animator.SetBool("Is_Grounded", true);
            is_Grounded_2 = true;
            animator.SetBool("Is_Jumping", false);
            isJumping = false;
        }

        rb.AddForce(JumpForces, ForceMode.VelocityChange);
    }
    void Move()
    {
        float currentSpeed = isRunning ? sprintSpeed : walkSpeed; // Ko�ma h�z�n� kontrol et
        Vector3 targetVelocity = new Vector3(move.x, 0, move.y) * currentSpeed; // Hedef h�z� belirle
        targetVelocity = transform.TransformDirection(targetVelocity); // Hedef h�z� d�nya koordinatlar�na �evir

        Vector3 currentVelocity = rb.velocity; // Karakterin mevcut h�z�n� al�r.
        Vector3 velocityChange = targetVelocity - currentVelocity; // H�z de�i�imini hesapla
        velocityChange.y = 0; // Y ekseninde herhangi bir h�z de�i�ikli�i yapma
        velocityChange = Vector3.ClampMagnitude(velocityChange, MaxForce); // H�z de�i�imini maksimum kuvvetle s�n�rla

        rb.AddForce(velocityChange, ForceMode.VelocityChange); // Rigidbody'ye h�z de�i�imini uygula

        bool isMoving = move.magnitude > 0;
        animator.SetBool("isMoving", isMoving); // Animator'a hareket durumunu bildir
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
    
    

    void LateUpdate()
    {
        Look();
    }
    public void SetGrounded(bool state) 
    {
        is_Grounded_2=state; //is_Grounded de�i�kenini State'e e�itle 
    }
    
}