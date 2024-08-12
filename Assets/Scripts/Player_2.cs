using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using static UnityEngine.Rendering.DebugUI;


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
    public bool is_Grounded_2;//Karakter zeminde mi?
    public bool isJumping; //Karakter zýpladý mý?
    public bool isRunning; //Karakter koþuyor mu?

    void Start()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

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
    public void OnRun(InputAction.CallbackContext context) // Player Input comp'daki Run'dan gelen deðeri alýr
    {
        if (context.performed)
        {
            isRunning = true; // Koþmayý baþlat
        }
        else if (context.canceled)
        {
            isRunning = false; // Koþmayý durdur
        }

        Sprint(); // Koþma fonksiyonunu çaðýr
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
        float currentSpeed = isRunning ? sprintSpeed : walkSpeed; // Koþma hýzýný kontrol et
        Vector3 targetVelocity = new Vector3(move.x, 0, move.y) * currentSpeed; // Hedef hýzý belirle
        targetVelocity = transform.TransformDirection(targetVelocity); // Hedef hýzý dünya koordinatlarýna çevir

        Vector3 velocityChange = targetVelocity - rb.velocity; // Hýz deðiþimini hesapla
        velocityChange.y = 0; // Y ekseninde herhangi bir hýz deðiþikliði yapma
        velocityChange = Vector3.ClampMagnitude(velocityChange, MaxForce); // Hýz deðiþimini maksimum kuvvetle sýnýrla

        rb.AddForce(velocityChange, ForceMode.VelocityChange); // Rigidbody'ye hýz deðiþimini uygula

        animator.SetBool("isRunning", isRunning); // Animator'a koþma durumunu bildir
    }
    void Jump()
    {
        Vector3 JumpForces = Vector3.zero;
        if (is_Grounded_2) //Eðer karakter zemindeyse,
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
        float currentSpeed = isRunning ? sprintSpeed : walkSpeed; // Koþma hýzýný kontrol et
        Vector3 targetVelocity = new Vector3(move.x, 0, move.y) * currentSpeed; // Hedef hýzý belirle
        targetVelocity = transform.TransformDirection(targetVelocity); // Hedef hýzý dünya koordinatlarýna çevir

        Vector3 currentVelocity = rb.velocity; // Karakterin mevcut hýzýný alýr.
        Vector3 velocityChange = targetVelocity - currentVelocity; // Hýz deðiþimini hesapla
        velocityChange.y = 0; // Y ekseninde herhangi bir hýz deðiþikliði yapma
        velocityChange = Vector3.ClampMagnitude(velocityChange, MaxForce); // Hýz deðiþimini maksimum kuvvetle sýnýrla

        rb.AddForce(velocityChange, ForceMode.VelocityChange); // Rigidbody'ye hýz deðiþimini uygula

        bool isMoving = move.magnitude > 0;
        animator.SetBool("isMoving", isMoving); // Animator'a hareket durumunu bildir
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
    
    

    void LateUpdate()
    {
        Look();
    }
    public void SetGrounded(bool state) 
    {
        is_Grounded_2=state; //is_Grounded deðiþkenini State'e eþitle 
    }
    
}