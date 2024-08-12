using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;


public class Player_2 : MonoBehaviour
{
    public Rigidbody rb; //Karakterin Rigidbody Componenti.
    public GameObject CameraHolder; //Karakterin çocugu olan kamera tutucu objesi.
    public float speed; // Karakterin hareket hýzý
    public Animator animator; //Karakterin animator kontrolü
    public float walkSpeed = 5f; //Karakterin yürüme hýzý
    public float sprintSpeed = 10f; //Karakterin koþma hýzý
    public Animator Character_Animator; //Karakterin animator kontrolü
    private bool Run = false; //Player Input componentindeki Run actionu için
    private Vector2 input;
    public float sensitivity; // Kamera duyarlýlýðý.
    public float MaxForce; // Makisumum kuvvet.
    public float JumpForce; // zýplama kuvveti.
    private Vector2 move, look; // Hareket ve bakýþ yönlerini tutan vektörler.
    private float LookRotation; //Kamera bakýþ açýsýný tutan deðiþken.
    public bool is_Grounded;//Karakter zeminde mi?

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();// Hareket girdisini alýr ve 'move' vektörüne atar.
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>(); //bakýþ girdisini alýr ve 'look' vektörüne atar.
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        Jump();
    }
    public void Onrun(InputValue value) // Player Input comp'daki Run'dan gelen deðeri alýr
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
    void Sprint() //Karakterin koþma aksiyonu için
    {
        float speed = Run ? sprintSpeed : walkSpeed;// Hareket hýzýný koþma durumuna göre ayarla
        Vector3 move = new Vector3(input.x, 0, input.y) * speed;// Hareket yönünü ve hýzýný belirle
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);// Hareketi Rigidbody bileþenine uygula
    }
    void Jump()
    {
        Vector3 JumpForces = Vector3.zero;
        if (is_Grounded) //Eðer karakter zemindeyse,
        {
            JumpForces = Vector3.up * JumpForce; 
        }
        rb.AddForce(JumpForces, ForceMode.VelocityChange);
    }
    void Move()
    {
        Vector3 CurrentVelocity = rb.velocity; // Karakterin mevcut hýzýný alýr.
        Vector3 TargetVelocity = new Vector3(move.x, 0, move.y); // Hareket girdisinden hedef hýzý oluþturur.
        TargetVelocity *= speed; // Hedef hýzý karakterin hareket hýzý ile çarpar.
        TargetVelocity = transform.TransformDirection(TargetVelocity); // Hedef hýzý dünya koordinatlarýna dönüþtürür.
        Vector3 VelocityChange = (TargetVelocity - CurrentVelocity);// Mevcut hýz ile hedef hýz arasýndaki farký hesaplar.
        VelocityChange = new Vector3(VelocityChange.x,0,VelocityChange.z); //karakterin direkt olarak düþmesini saðladým.
        Vector3.ClampMagnitude(VelocityChange, MaxForce);// Hýz deðiþimini maksimum kuvvetle sýnýrlar.
        rb.AddForce(VelocityChange, ForceMode.VelocityChange);// Rigidbody'ye hýz deðiþimini uygular.
    }
    
    void Look()
    {
        //Dönüþ için
        transform.Rotate(Vector3.up * look.x * sensitivity);

        //Bakýþ için
        LookRotation += (-look.y * sensitivity);
        LookRotation = Mathf.Clamp(LookRotation, -90, 90); //Kameranýn bakýþ açýlarýný sýnýrlamak için.
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
        is_Grounded=state; //is_Grounded deðiþkenini State'e eþitle 
    }
    
}