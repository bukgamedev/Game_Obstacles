using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator Player_Animator; // Oyuncunun Animatörü
    public Rigidbody Rigidbody; //Karakterin rigidbody'si
    public float Walk_Speed, WalkBack_Speed, OldWalking_Speed, Run_Speed,BackRun_Speed, Rotate_Speed;
    //Yürüme hýzý, geri yürüme hýzý, Eski yürüme hýzý, Koþma hýzý, Geri koþma hýzý, Dönüþ hýzý
    public bool walking; //Karakter yürüyor mu?
    public Transform PlayerTansform; //Karakterin transform deðeri
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) //W tuþuna basýldýðýnda
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
        if (Input.GetKeyDown(KeyCode.W)) //W'a basýlý tutarsam yürümeeyi baþlat.
        {
            Player_Animator.SetTrigger("walk");
            Player_Animator.ResetTrigger("idle");
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.W)) // Eðer W tuþundan elimi çekersem yürümeyi durdur.
        {
            Player_Animator.ResetTrigger("walk");
            Player_Animator.SetTrigger("idle");
            walking = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Player_Animator.SetTrigger("walkback");
            Player_Animator.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Player_Animator.ResetTrigger("walkback");
            Player_Animator.SetTrigger("idle");
        }
        if (Input.GetKey(KeyCode.A)) //Klavyeden a tuþuna basýlýrsa
        {
            PlayerTansform.Rotate(0, -Rotate_Speed * Time.deltaTime,0); //Karakter sola doðru dönecektir.
        } 
        if (Input.GetKey(KeyCode.D))//Klavyeden d tuþuna basýlýrsa 
        {
            PlayerTansform.Rotate(0, Rotate_Speed * Time.deltaTime, 0); //Karakter saða doðru dönecektir.
        }
        if (walking == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)) // Sol Shift tuþuna basýlýrsa
            {
                Walk_Speed = Walk_Speed + Run_Speed; // Karakterin yürüme hýzýný, Yürüme hýzý ve Koþma hýzýnýn toplamýna eþitle. 
                Player_Animator.SetTrigger("run"); //Karakterin koþma animasyonunu oynat.
                Player_Animator.ResetTrigger("walk"); //Karakter koþacaðý için walk Animasyonunu resetle.
            }
            if (Input.GetKeyUp(KeyCode.LeftShift)) //Sol Shift tuþundan parmak çekilirse
            {
                Walk_Speed = OldWalking_Speed; //Yürüme hýzýný, eski yürüme hýzýna eþitle.
                Player_Animator.ResetTrigger("run"); //Karakter koþmayý durduracaðý için, koþma animasyonunu resetle.
                Player_Animator.SetTrigger("walk"); ////Karakterin yürüme animasyonunu oynat.
            }
        }
    }

}