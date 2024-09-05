using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public GameObject[] Arrow; // Birden fazla ok
    public float delayBetweenArrows = 0.5f; // Oklar aras�ndaki gecikme s�resi
    private bool triggered = false; // Tekrar tetiklenmesini engellemek i�in

    void OnTriggerEnter(Collider other)
    {
        {
            if (!triggered && other.CompareTag("Player")) // Sadece oyuncu tetikleyince ve sadece bir kez
            {
                Debug.Log("Ok Trigger'�na girildi.");
                triggered = true;
                StartCoroutine(DropArrows());
            }
        }
    }
    IEnumerator DropArrows() //Oklar�n yukar�dan d��mesini sa�lamak i�in.
    {
        foreach (GameObject arrow in Arrow)
        {
            arrow.GetComponent<Animation>().Play("Arrows"); // Okun d��me animasyonu
            yield return new WaitForSeconds(delayBetweenArrows); // Oklar aras�nda bekleme s�resi
        }

    }
}