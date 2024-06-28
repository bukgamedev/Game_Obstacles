using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator Player_Animator; // Oyuncunun Animat�r�
    public Rigidbody Rigidbody; //Karakterin rigidbody'si
    public float Walk_Speed, WalkBack_Speed, OldWalking_Speed, Run_Speed,BackRun_Speed, Rotate_Speed;
    //Y�r�me h�z�, geri y�r�me h�z�, Eski y�r�me h�z�, Ko�ma h�z�, Geri ko�ma h�z�, D�n�� h�z�
    public bool walking; //Karakter y�r�yor mu?
    public Transform PlayerTansform; //Karakterin transform de�eri
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) //W tu�una bas�ld���nda
        {
            Rigidbody.velocity = transform.forward * Walk_Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Rigidbody.velocity = -transform.forward * WalkBack_Speed * Time.deltaTime;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) //W'a bas�l� tutarsam y�r�meeyi ba�lat.
        {
            Player_Animator.SetTrigger("Walk");
            Player_Animator.ResetTrigger("Idle");
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.W)) // E�er W tu�undan elimi �ekersem y�r�meyi durdur.
        {
            Player_Animator.ResetTrigger("Walk");
            Player_Animator.SetTrigger("Idle");
            walking = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Player_Animator.SetTrigger("Walk_Back");
            Player_Animator.ResetTrigger("Idle");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Player_Animator.ResetTrigger("Walk_Back");
            Player_Animator.SetTrigger("Idle");
        }
        if (Input.GetKey(KeyCode.A)) //Klavyeden a tu�una bas�l�rsa
        {
            PlayerTansform.Rotate(0, -Rotate_Speed * Time.deltaTime,0); //Karakter sola do�ru d�necektir.
        } 
        if (Input.GetKey(KeyCode.D))//Klavyeden d tu�una bas�l�rsa 
        {
            PlayerTansform.Rotate(0, Rotate_Speed * Time.deltaTime, 0); //Karakter sa�a do�ru d�necektir.
        }
        if (walking == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)) // Sol Shift tu�una bas�l�rsa
            {
                Walk_Speed = Walk_Speed + Run_Speed; // Karakterin y�r�me h�z�n�, Y�r�me h�z� ve Ko�ma h�z�n�n toplam�na e�itle. 
                Player_Animator.SetTrigger("Run"); //Karakterin ko�ma animasyonunu oynat.
                Player_Animator.ResetTrigger("Walk"); //Karakter ko�aca�� i�in walk Animasyonunu resetle.
            }
            if (Input.GetKeyUp(KeyCode.LeftShift)) //Sol Shift tu�undan parmak �ekilirse
            {
                Walk_Speed = OldWalking_Speed; //Y�r�me h�z�n�, eski y�r�me h�z�na e�itle.
                Player_Animator.ResetTrigger("Run"); //Karakter ko�may� durduraca�� i�in, ko�ma animasyonunu resetle.
                Player_Animator.SetTrigger("Walk"); ////Karakterin y�r�me animasyonunu oynat.
            }
        }
    }

}