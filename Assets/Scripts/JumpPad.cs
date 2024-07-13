using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JumpPad : MonoBehaviour
{
    public float JumpPower; //Z�platma g�c�
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Rigidbody rb))
        {
            rb.AddForce(transform.up * JumpPower); //Karakter yukar� veya �apraz z�playaca�� i�in transform.up kullanabilirim.
        }
    }
    
}
