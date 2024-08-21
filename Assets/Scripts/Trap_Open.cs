using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Open : MonoBehaviour
{
    public GameObject Trap_Door; //Trapdoor objesi
    private void OnTriggerEnter(Collider other)
    {
        Trap_Door.GetComponent<Animation>().Play("TrapDoor"); //Trap_Door objesinin Animation componentine eri� ve TrapDoor ad�ndaki animasyonu oynat.
    }
}
