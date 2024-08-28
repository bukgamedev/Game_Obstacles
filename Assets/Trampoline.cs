using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float BounceForce = 10;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Rigidbody PlayerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (PlayerRigidbody!=null)
            {
                //PlayerRigidbody null deðilse Güç uygulanacak
            }
        }
    }
}
