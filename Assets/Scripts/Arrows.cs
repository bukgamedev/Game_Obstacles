using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public GameObject Arrow; //Ok objesi
    void OnTriggerEnter()
    {
        Debug.Log("Ok Trigger'ýna girildi.");
        Arrow.GetComponent<Animation>().Play("Arrows");
    }
}
