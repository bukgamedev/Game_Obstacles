using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;//Karakterin Yürüme hýzý
    public float Movement_speed = 125f;//Karakterin Yürüme hýzý
    public float rotation_Speed; //Dönme hýzý
    public float Jump_Speed; //zýplama hýzý
    public bool Is_Moving; //Kareket var mý?
    public bool Is_Jumping; //Karakter zýpladý mý?
    public bool Is_Grounded; //Karakter yerde mi?
    public float JumpButtonGracePediod; //Zýplama hýzý süresi
    public Animator animator; //Karakterin animator kontrolü
    public CharacterController characterController; //Karakter kontrol component'ý
    private float ySpeed; //Y eksenindeki hýzý
    private float originalStepOffset; //Karakter kontrol component'ý içerisindeki ayar
    private float? lastGroundedTÝme;
    private float? JumpButtonPressedTime;
    private Transform platformTransform = null; //Platformun transform deðeri
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();
        ySpeed += Physics.gravity.y * Time.deltaTime;
        if (characterController.isGrounded)
        {
            lastGroundedTÝme = Time.time;
        }
        if (Input.GetButtonDown("Jump"))
        {
            JumpButtonPressedTime = Time.time;
        }
        if (Time.time - lastGroundedTÝme <= JumpButtonGracePediod)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            animator.SetBool("Is_Grounded", true);
            Is_Grounded = true;
            animator.SetBool("Is_Jumping", false);
            Is_Jumping = false;
            if (Time.time - JumpButtonPressedTime <= JumpButtonGracePediod)
            {
                ySpeed = Jump_Speed;
                animator.SetBool("Is_Jumping", true);
                Is_Jumping = true;
                JumpButtonPressedTime = null;
                lastGroundedTÝme = null;
            }

        }
        else
        {
            characterController.stepOffset = 0;
            animator.SetBool("Is_Grounded", false);
            Is_Grounded = false;
        }
        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;
        characterController.Move(velocity * Time.deltaTime);
        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("Walk", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotation_Speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Is_Moving == true) //Shift'e basýnca karakter koþacak
        {
            animator.SetBool("IsRunning", true);
            transform.position += transform.forward * Time.deltaTime * Movement_speed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) //Sadece Shift'i býrakýrsak karakter yürüyecek.
        {
            animator.SetBool("IsRunning", false);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotation_Speed * Time.deltaTime);
        }
        if (platformTransform != null)
        {
            transform.position = platformTransform.position;
            transform.rotation = platformTransform.rotation;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RotatingPlatform"))
        {
            platformTransform = collision.transform;
            transform.SetParent(platformTransform);
        }
        if (collision.gameObject.CompareTag("Press_Obstacle"))// Karakter Press engeline dokunursa
        {
            // Karakterin scale x deðerini 0.1f yap
            Vector3 newScale = transform.localScale;
            newScale.x = 0.1f;
            transform.localScale = newScale;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("RotatingPlatform"))
        {
            transform.SetParent(null);
            platformTransform = null;
        }
    }
}