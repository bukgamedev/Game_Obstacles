using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Trigger : MonoBehaviour
{
    public Moving_Platform Platform; //Moving_Platform script dosyas�ndaki platform'u burada da kullanabilirim art�k.
    private void OnTriggerEnter(Collider other)
    {
        Platform.NextPlatform();
    }
}
