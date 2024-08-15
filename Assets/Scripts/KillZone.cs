using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public Vector3 CheckPos;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.transform.position = CheckPos;
            /*
            Önceki kodlar.
            other.GetComponent<Health>().Die();
            Debug.Log("Karakter öldü");*/
        }
    }
}
