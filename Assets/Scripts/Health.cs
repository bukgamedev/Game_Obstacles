using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Vector3 respawnPosition = new Vector3(0, 0, 0);
    public float respawnDelay = 1f; // �l�m sonras� bekleyece�i s�re (1 saniye)
    public float deadDuration = 1f; // �l� durumda kalaca�� s�re (1 saniye)

    private bool isDead = false; // Karakterin �l� olup olmad���n� takip etmek i�in kullan�lacak flag

    private float deathTime = 0f; // Karakterin �ld��� zaman� takip etmek i�in kullan�lacak de�i�ken

    public void Die()
    {
        if (isDead)
        {
            return; // Karakter zaten �l�yse tekrar �l�m i�lemine izin verme
        }

        isDead = true; // Karakteri �l� olarak i�aretle
        deathTime = Time.time; // �l�m zaman�n� kaydet
        Debug.Log("Karakter �ld�!");

        // Karakterin hareketlerini durdur
        var movement = GetComponent<Player>();
        if (movement != null)
        {
            movement.enabled = false;
        }

        // Karakteri devre d��� b�rak
        gameObject.SetActive(false);

        // Belirli bir s�re sonra respawn i�lemini ger�ekle�tir
        Invoke("Respawn", respawnDelay + deadDuration); // respawnDelay s�resi + deadDuration s�resi kadar beklet
    }

    void Respawn()
    {
        // Karakteri yeniden belirli bir konuma getir
        transform.position = respawnPosition;
        gameObject.SetActive(true);

        // Karakterin hareketlerini yeniden etkinle�tir
        var movement = GetComponent<Player>();
        if (movement != null)
        {
            movement.enabled = true;
        }

        // �l� durumunu s�f�rla
        isDead = false;

        Debug.Log("Karakter yeniden do�du.");
    }

    private void Update()
    {
        // E�er karakter �ld�yse ve �l� s�resi ge�tiyse respawn i�lemini ger�ekle�tir
        if (isDead && Time.time >= deathTime + deadDuration)
        {
            Respawn();
        }
    }
}