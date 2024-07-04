using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerObjects : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().Die();
            Debug.Log("Karakter öldü");
        }
    }
    
}