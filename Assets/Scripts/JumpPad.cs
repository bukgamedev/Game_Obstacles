using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JumpPad : MonoBehaviour
{
    public float JumpPower; //Zýplatma gücü
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Rigidbody rb))
        {
            rb.AddForce(transform.up * JumpPower); //Karakter yukarý veya çapraz zýplayacaðý için transform.up kullanabilirim.
        }
    }
    
}
