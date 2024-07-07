using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public GameObject explosionEffectPrefab; // Patlama efekti prefabý
    public float explosionRadius = 1f; // 2 metre çapýndaki çemberin yarýçapý
    public LayerMask playerLayer; // Sadece oyuncuyu kontrol etmek için katman

    private void OnCollisionEnter(Collision collision)
    {

        
        if (collision.gameObject.CompareTag("Ground"))// Yalnýzca Zemine düþtüðünde patlama efekti oynat
        {
            
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);// Patlama efektini oluþtur

            
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, playerLayer);// Çemberin içindeki karakteri kontrol et
            foreach (Collider nearbyObject in colliders)
            {
                if (nearbyObject.CompareTag("Player"))
                {
                    // Karakteri öldür
                    Debug.Log("Character is dead!");
                    // Karakteri öldürme kodunu buraya ekle, örneðin:
                    // nearbyObject.GetComponent<Character>().Die();
                }
            }            
            Destroy(gameObject);// Gülleyi yok et
        }
    }
}