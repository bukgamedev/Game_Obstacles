using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Check : MonoBehaviour
{
    public Player_2 Player_2; //Player_2 script dosyasýna ulaþmak için.
    private void OnTriggerEnter(Collider other)//Karakter zemine temas ediyorsa.
    {
        if (other.gameObject == Player_2.gameObject)
        {
            return;
        }
        Player_2.SetGrounded(true);
    }
    private void OnTriggerStay(Collider other)//Karakter zeminde kalmaya devam ediyorsa.
    {
        if (other.gameObject == Player_2.gameObject)
        {
            return;
        }
        Player_2.SetGrounded(true);
    }
    private void OnTriggerExit(Collider other)//Karakter zeminden ayrýldýysa.
    {
        if (other.gameObject == Player_2.gameObject)
        {
            return;
        }
        Player_2.SetGrounded(false); //Karakter zeminden ayrýldýysa setgrounded False olsun.
    }
    
}
