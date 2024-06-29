using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;//Karakterin ko�ma h�z�
    public float rotation_Speed; //D�nme h�z�
    public float Jump_Speed; //z�plama h�z�
    public float JumpButtonGracePediod; //Z�plama h�z� s�resi
    public Animator animator; //Karakterin animator kontrol�
    public CharacterController characterController; //Karakter kontrol component'�
    private float ySpeed; //Y eksenindeki h�z�
    private float originalStepOffset; //Karakter kontrol component'� i�erisindeki ayar
    private float? lastGroundedT�me;
    private float? JumpButtonPressedTime;

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
            lastGroundedT�me = Time.time;
        }
        if (Input.GetButtonDown("Jump"))
        {
            JumpButtonPressedTime = Time.time;
        }
        if (Time.time - lastGroundedT�me <= JumpButtonGracePediod)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            if (Time.time - JumpButtonPressedTime <= JumpButtonGracePediod)
            {
                ySpeed = Jump_Speed;
                JumpButtonPressedTime = null;
                lastGroundedT�me = null;
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }
        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;
        characterController.Move(velocity * Time.deltaTime);
        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsRunning", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotation_Speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }
}