using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public GameObject[] Arrow; // Birden fazla ok
    public float delayBetweenArrows = 0.5f; // Oklar arasýndaki gecikme süresi
    private bool triggered = false; // Tekrar tetiklenmesini engellemek için

    void OnTriggerEnter()
    {
        Debug.Log("Ok Trigger'ýna girildi.");
        //Arrow[].GetComponent<Animation>().Play("Arrows");
    }
}
