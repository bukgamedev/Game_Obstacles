using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public KillZone deathwall; //Killzone scripti.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            deathwall.CheckPos = other.transform.position; //deathwalldaki poziyonun pozisyonunu karakterin pozisyonu yapar. 
        }
    }
}
