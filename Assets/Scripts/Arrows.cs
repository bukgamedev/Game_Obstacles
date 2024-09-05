using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public GameObject[] Arrow; // Birden fazla ok
    public float delayBetweenArrows = 0.5f; // Oklar arasýndaki gecikme süresi
    private bool triggered = false; // Tekrar tetiklenmesini engellemek için

    void OnTriggerEnter(Collider other)
    {
        {
            if (!triggered && other.CompareTag("Player")) // Sadece oyuncu tetikleyince ve sadece bir kez
            {
                Debug.Log("Ok Trigger'ýna girildi.");
                triggered = true;
                StartCoroutine(DropArrows());
            }
        }
    }
    IEnumerator DropArrows() //Oklarýn yukarýdan düþmesini saðlamak için.
    {
        foreach (GameObject arrow in Arrow)
        {
            arrow.GetComponent<Animation>().Play("Arrows"); // Okun düþme animasyonu
            yield return new WaitForSeconds(delayBetweenArrows); // Oklar arasýnda bekleme süresi
        }

    }
}