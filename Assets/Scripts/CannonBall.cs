using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public GameObject explosionEffectPrefab; // Patlama efekti prefab�
    public float explosionRadius = 1f; // 2 metre �ap�ndaki �emberin yar��ap�
    public LayerMask playerLayer; // Sadece oyuncuyu kontrol etmek i�in katman

    private void OnCollisionEnter(Collision collision)
    {

        
        if (collision.gameObject.CompareTag("Ground"))// Yaln�zca Zemine d��t���nde patlama efekti oynat
        {
            
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);// Patlama efektini olu�tur

            
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, playerLayer);// �emberin i�indeki karakteri kontrol et
            foreach (Collider nearbyObject in colliders)
            {
                if (nearbyObject.CompareTag("Player"))
                {
                    // Karakteri �ld�r
                    Debug.Log("Character is dead!");
                    // Karakteri �ld�rme kodunu buraya ekle, �rne�in:
                    // nearbyObject.GetComponent<Character>().Die();
                }
            }            
            Destroy(gameObject);// G�lleyi yok et
        }
    }
}