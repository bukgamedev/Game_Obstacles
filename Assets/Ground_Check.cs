using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Check : MonoBehaviour
{
    public Player_2 Player_2; //Player_2 script dosyas�na ula�mak i�in.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player_2.gameObject)
        {
            return;
        }
        Player_2.SetGrounded(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player_2.gameObject)
        {
            return;
        }
        Player_2.SetGrounded(false); //Karakter zeminden ayr�ld�ysa setgrounded False olsun.
    }
    
}
