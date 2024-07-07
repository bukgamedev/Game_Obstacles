using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public GameObject ExplosionEffectPrefab; // Patlama efekti prefabý
    public LayerMask playerLayer; // Sadece oyuncuyu kontrol etmek için katman
    public float delay = 1.0f;
    public float radius = 5.0f;// 5 metre çapýndaki patlamanýn yarýçapý
    public float force = 1500.0f; //Güllenin patlama gücü 
    public bool ExplodeOnCollision = false;
    public float DelayTimer; //gecikme 
    public float EffectDisplayTime = 3.0f; //Efekt Görüntüleme Süresi

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
        if (ExplosionEffectPrefab != null) //Explosioneffectprefab null deðilse
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
            if (rigidbody != null) //Rigidbody null deðilse,
            {
                rigidbody.AddExplosionForce(force, transform.position, radius); 
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))// Yalnýzca Zemine düþtüðünde patlama efekti oynat
        {
            
            Instantiate(ExplosionEffectPrefab, transform.position, Quaternion.identity);// Patlama efektini oluþtur

            
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, playerLayer);// Çemberin içindeki karakteri kontrol et
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