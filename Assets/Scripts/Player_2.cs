using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_2 : MonoBehaviour
{
    public Rigidbody rb; //Karakterin Rigidbody Componenti.
    public GameObject CameraHolder; //Karakterin �ocugu olan kamera tutucu objesi.
    public float speed; // Karakterin hareket h�z�.
    public float sensiivity; // Kamera duyarl�l���.
    public float MaxForce; // Kamera duyarl�l���.
    private Vector2 move, look; // Hareket ve bak�� y�nlerini tutan vekt�rler.
    private float LookRotation; //Kamera bak�� a��s�n� tutan de�i�ken.

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();// Hareket girdisini al�r ve 'move' vekt�r�ne atar.
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>(); //bak�� girdisini al�r ve 'look' vekt�r�ne atar.
    }
    private void FixedUpdate()
    {
        Vector3 CurrentVelocity = rb.velocity; // Karakterin mevcut h�z�n� al�r.
        Vector3 TargetVelocity = new Vector3(move.x,0,move.y); // Hareket girdisinden hedef h�z� olu�turur.
        TargetVelocity *= speed; // Hedef h�z� karakterin hareket h�z� ile �arpar.
        TargetVelocity = transform.TransformDirection(TargetVelocity); // Hedef h�z� d�nya koordinatlar�na d�n��t�r�r.
        Vector3 VelocityChange = (TargetVelocity - CurrentVelocity);// Mevcut h�z ile hedef h�z aras�ndaki fark� hesaplar.
        Vector3.ClampMagnitude(VelocityChange, MaxForce);// H�z de�i�imini maksimum kuvvetle s�n�rlar.
        rb.AddForce(VelocityChange, ForceMode.VelocityChange);// Rigidbody'ye h�z de�i�imini uygular.
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
