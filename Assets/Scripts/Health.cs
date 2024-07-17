using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Vector3 respawnPosition = new Vector3(0, 0, 0);
    public float respawnDelay = 1f; // Ölüm sonrasý bekleyeceði süre (1 saniye)
    public float deadDuration = 1f; // Ölü durumda kalacaðý süre (1 saniye)
    private bool isDead = false; // Karakterin ölü olup olmadýðýný takip etmek için kullanýlacak flag
    private float deathTime = 0f; // Karakterin öldüðü zamaný takip etmek için kullanýlacak deðiþken
    public void Die()
    {
        if (isDead)
        {
            return; // Karakter zaten ölüyse tekrar ölüm iþlemine izin verme
        }

        isDead = true; // Karakteri ölü olarak iþaretle
        deathTime = Time.time; // Ölüm zamanýný kaydet
        Debug.Log("Karakter Öldü!");

        var movement = GetComponent<Player>();
        if (movement != null)
        {
            movement.enabled = false;// Karakterin hareketlerini durdur
        }

        // Karakteri devre dýþý býrak
        gameObject.SetActive(false);

        // Belirli bir süre sonra respawn iþlemini gerçekleþtir
        Invoke("Respawn", respawnDelay); // respawnDelay süresi kadar beklet    

         void Respawn()
        {
            // Karakteri yeniden belirli bir konuma getir
            transform.position = respawnPosition;
            gameObject.SetActive(true);

            // Karakterin hareketlerini yeniden etkinleþtir
            var movement = GetComponent<Player>();
            if (movement != null)
            {
                movement.enabled = true;
            }
            Vector3 newScale = transform.localScale; // Karakterin scale deðerini eski haline getirmek için
            newScale.x = 1f;
            transform.localScale = newScale;
            // Ölü durumunu sýfýrla
            isDead = false;

            Debug.Log("Karakter yeniden doðdu.");
        }
    }

    private void Update()
    {
        // Eðer karakter öldüyse ve ölü süresi geçtiyse respawn iþlemini gerçekleþtir
        if (isDead && Time.time >= deathTime + deadDuration)
        {
            //Respawn();
        }
    }
}