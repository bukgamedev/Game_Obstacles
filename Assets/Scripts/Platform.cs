using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private void Start()
    {
        
    }
    private void Update()
    {
        rb.velocity = Vector3.forward * speed;
    }
}
