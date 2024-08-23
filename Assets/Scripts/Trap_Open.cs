using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Open : MonoBehaviour
{
    public GameObject Trap_Door; //Trapdoor objesi
    private void OnTriggerEnter()
    {
        Debug.Log("Tuza�a temas edildi.");
        Trap_Door.GetComponent<Animation>().Play("TrapDoor"); //Trap_Door objesinin Animation componentine eri� ve TrapDoor ad�ndaki animasyonu oynat.
    }
}
