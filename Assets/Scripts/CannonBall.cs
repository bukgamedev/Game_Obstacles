using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public GameObject ExplosionEffectPrefab; // Patlama efekti prefab�
    public LayerMask playerLayer; // Sadece oyuncuyu kontrol etmek i�in katman
    public float delay = 1.0f;
    public float radius = 5.0f;// 5 metre �ap�ndaki patlaman�n yar��ap�
    public float force = 1500.0f; //G�llenin patlama g�c� 
    public bool ExplodeOnCollision = false;
    public float DelayTimer; //gecikme 
    public float EffectDisplayTime = 3.0f; //Efekt G�r�nt�leme S�resi

    private void Awake()
    {
        DelayTimer = 0.0f;
    }
    private void Update()
    {
        DelayTimer += Time.deltaTime;
        if (DelayTimer >= delay && !ExplodeOnCollision)
        {
            DoExplosion();
            Destroy(gameObject);//Objeyi yok et.
        }
    }
    private void DoExplosion()
    {
        HandleEffect();
        HandleDestruction();
    }
    private void HandleEffect()
    {
        if (ExplosionEffectPrefab != null) //Explosioneffectprefab null de�ilse
        {
            GameObject effect = Instantiate(ExplosionEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, EffectDisplayTime);
        }
        
    }
    private void HandleDestruction()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders)
        {
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();
            if (rigidbody != null) //Rigidbody null de�ilse,
            {
                rigidbody.AddExplosionForce(force, transform.position, radius); 
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))// Yaln�zca Zemine d��t���nde patlama efekti oynat
        {
            
            Instantiate(ExplosionEffectPrefab, transform.position, Quaternion.identity);// Patlama efektini olu�tur

            
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, playerLayer);// �emberin i�indeki karakteri kontrol et
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