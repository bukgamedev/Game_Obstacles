using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public GameObject[] Arrow; // Birden fazla ok
    public float delayBetweenArrows = 0.5f; // Oklar aras�ndaki gecikme s�resi
    private bool triggered = false; // Tekrar tetiklenmesini engellemek i�in

    void OnTriggerEnter()
    {
        Debug.Log("Ok Trigger'�na girildi.");
        //Arrow[].GetComponent<Animation>().Play("Arrows");
    }
}
