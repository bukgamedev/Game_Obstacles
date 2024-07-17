using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerObjects : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // �arp��an objenin Player tag'ine sahip olup olmad���n� kontrol et
        if (collision.gameObject.CompareTag("Player"))
        {
            // �arp��an objenin press_Machine tag'ine sahip olup olmad���n� kontrol et
            if (collision.collider.CompareTag("Press_Obstacle"))
            {
                StartCoroutine(ShrinkAndDie(collision.gameObject));
            }
            else
            {
                // Player objesinin Health bile�enine eri� ve Die metodunu �a��r
                var health = collision.gameObject.GetComponent<Health>();
                if (health != null)
                {
                    health.Die(); //Health script dosyas�ndaki die fonksiyonunu �a��r.
                    Debug.Log("Karakter �ld�");
                }
            }
        }
    }

    private IEnumerator ShrinkAndDie(GameObject player)
    {
        // Karakterin scale x de�erini 0.1f yap
        Vector3 newScale = player.transform.localScale;
        newScale.x = 0.1f;
        player.transform.localScale = newScale;

        // 2 saniye bekle
        yield return new WaitForSeconds(2f);

        // Karakterin Die metodunu �a��r
        var health = player.GetComponent<Health>();
        if (health != null)
        {
            health.Die();
        }
    }
}