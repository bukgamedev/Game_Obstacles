using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject CannonBallPrefab; // Gülle prefabý
    public Transform FirePoint; // Topun gülleyi atacaðý nokta
    public float FireInterval = 1f; // 5 saniyede bir ateþleme
    public float launchForceForward = 20f; // Gülleyi ileriye atma kuvveti -Ýstediðin deðeri gir.-
    public float launchForceUpward = 4f; // Gülleyi yukarýya atma kuvveti -Ýstediðin deðeri gir.-

    public GameObject explosionEffectPrefab; // Patlama efekti prefabý
    public float explosionRadius = 1f; // 2 metre çapýndaki çemberin yarýçapý

    private void Start()
    {
        InvokeRepeating("FireCannonball", FireInterval, FireInterval);
    }

    void FireCannonball()
    {
        GameObject cannonball = Instantiate(CannonBallPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody rb = cannonball.GetComponent<Rigidbody>();
        Vector3 launchDirection = -FirePoint.right * launchForceForward + FirePoint.up * launchForceUpward; // -X yönü için firePoint.right kullanýyoruz
        rb.AddForce(launchDirection, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);// Patlama efektini oluþtur
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);// Çemberin içindeki karakteri kontrol et
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.CompareTag("Player"))
            {
                // Karakteri öldür
                // Öldürme kodunu buraya ekle
                Debug.Log("Character is dead!");
            }
        }
        Destroy(gameObject);// Gülleyi yok et
    }
}