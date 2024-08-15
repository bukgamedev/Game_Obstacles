using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public Vector3 CheckPos; //Kontrol noktasý pozisyonu deðiþkeni.

    public GameObject Player; //Oyuncu GameObject'ine referans.

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //Oyuncu tagindeki nesnesiyle çarpýþma varsa
        {
            Rigidbody rb = Player.GetComponent<Rigidbody>(); //  Oyuncunun Rigidbody bileþenini alýr.
            rb.velocity = Vector3.zero; //  Karakterin hýzýný sýfýrlar.
            Player.transform.position = CheckPos; //  Karakteri checkpoint pozisyonuna ýþýnlar.

        /*
        Önceki kodlar.
        other.GetComponent<Health>().Die();
        Debug.Log("Karakter öldü");*/
        }


    }
}

