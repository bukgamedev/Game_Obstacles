using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject CannonBallPrefab; // G�lle prefab�
    public Transform FirePoint; // Topun g�lleyi ataca�� nokta
    public float FireInterval = 1f; // 5 saniyede bir ate�leme
    public float launchForceForward = 20f; // G�lleyi ileriye atma kuvveti -�stedi�in de�eri gir.-
    public float launchForceUpward = 4f; // G�lleyi yukar�ya atma kuvveti -�stedi�in de�eri gir.-

    public GameObject explosionEffectPrefab; // Patlama efekti prefab�
    public float explosionRadius = 1f; // 2 metre �ap�ndaki �emberin yar��ap�

    private void Start()
    {
        InvokeRepeating("FireCannonball", FireInterval, FireInterval);
    }

    void FireCannonball()
    {
        GameObject cannonball = Instantiate(CannonBallPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody rb = cannonball.GetComponent<Rigidbody>();
        Vector3 launchDirection = -FirePoint.right * launchForceForward + FirePoint.up * launchForceUpward; // -X y�n� i�in firePoint.right kullan�yoruz
        rb.AddForce(launchDirection, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);// Patlama efektini olu�tur
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);// �emberin i�indeki karakteri kontrol et
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.CompareTag("Player"))
            {
                // Karakteri �ld�r
                // �ld�rme kodunu buraya ekle
                Debug.Log("Character is dead!");
            }
        }
        Destroy(gameObject);// G�lleyi yok et
    }
}