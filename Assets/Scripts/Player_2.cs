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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
