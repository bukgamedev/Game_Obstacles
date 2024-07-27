using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Trigger : MonoBehaviour
{
    public Moving_Platform Platform; //Moving_Platform script dosyasýndaki platform'u burada da kullanabilirim artýk.
    private void OnTriggerEnter(Collider other)
    {
        Platform.NextPlatform();
    }
}
