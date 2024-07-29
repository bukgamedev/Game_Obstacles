using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed;
    public float Force_Speed;
    public bool Timer;
    private void Start()
    {
        Force_Speed = Speed;
    }
    private void FixedUpdate()
    {
        rb.velocity = Vector3.forward * Force_Speed;
        if (Timer)
        {
            if (Force_Speed>0)
            {
                Force_Speed = -Speed; //Platform bir yere dokunduðunda - hýzda geriye doðru gidecek.
                Timer = false; 
            }
            else if(Force_Speed < 0)
            {
                Force_Speed = Speed;
                Timer = false;

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Untagged")
        {
            Timer = true;
        }
    }
}
