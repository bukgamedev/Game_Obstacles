using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed;
    public float Force_Speed;
    public bool Timer;

    public float time;
    public float Interval; //Aralýk
    private void Start()
    {
        Force_Speed = Speed;
    }
    private void FixedUpdate()
    {
        rb.velocity = Vector3.forward * Force_Speed;
        if (Timer)
        {
            time += Time.deltaTime;
            if (time > Interval)
            {
                if (Force_Speed > 0)
                {
                    Force_Speed = -Speed; //Platform bir yere dokunduðunda - hýzda geriye doðru gidecek.
                    Timer = false;
                    time = 0;
                }
                else if (Force_Speed < 0)
                {
                    Force_Speed = Speed;
                    Timer = false;
                    time = 0;
                }
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
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();//Karakterin rb özelliði.
            rb.velocity = new Vector3(this.rb.velocity.x,rb.velocity.y, this.rb.velocity.z); //Kodun kendi içerisindeki rb özelliðine ulaþmak için this.rb yazdým. Yani bu rb, Platformun rb özelliði.
        }
    }

}
