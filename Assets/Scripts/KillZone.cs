using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public Vector3 CheckPos; //Kontrol noktas� pozisyonu de�i�keni.

    public GameObject Player; //Oyuncu GameObject'ine referans.

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //Oyuncu tagindeki nesnesiyle �arp��ma varsa
        {
            Rigidbody rb = Player.GetComponent<Rigidbody>(); //  Oyuncunun Rigidbody bile�enini al�r.
            rb.velocity = Vector3.zero; //  Karakterin h�z�n� s�f�rlar.
            Player.transform.position = CheckPos; //  Karakteri checkpoint pozisyonuna ���nlar.

        /*
        �nceki kodlar.
        other.GetComponent<Health>().Die();
        Debug.Log("Karakter �ld�");*/
        }


    }
}

