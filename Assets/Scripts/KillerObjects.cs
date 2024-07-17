using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerObjects : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Çarpýþan objenin Player tag'ine sahip olup olmadýðýný kontrol et
        if (collision.gameObject.CompareTag("Player"))
        {
            // Çarpýþan objenin press_Machine tag'ine sahip olup olmadýðýný kontrol et
            if (collision.collider.CompareTag("Press_Obstacle"))
            {
                StartCoroutine(ShrinkAndDie(collision.gameObject));
            }
            else
            {
                // Player objesinin Health bileþenine eriþ ve Die metodunu çaðýr
                var health = collision.gameObject.GetComponent<Health>();
                if (health != null)
                {
                    health.Die(); //Health script dosyasýndaki die fonksiyonunu çaðýr.
                    Debug.Log("Karakter öldü");
                }
            }
        }
    }

    private IEnumerator ShrinkAndDie(GameObject player)
    {
        // Karakterin scale x deðerini 0.1f yap
        Vector3 newScale = player.transform.localScale;
        newScale.x = 0.1f;
        player.transform.localScale = newScale;

        // 2 saniye bekle
        yield return new WaitForSeconds(2f);

        // Karakterin Die metodunu çaðýr
        var health = player.GetComponent<Health>();
        if (health != null)
        {
            health.Die();
        }
    }
}