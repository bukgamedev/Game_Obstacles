using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_2 : MonoBehaviour
{
    public Rigidbody rb; //Karakterin Rigidbody Componenti.
    public GameObject CameraHolder; //Karakterin çocugu olan kamera tutucu objesi.
    public float speed; // Karakterin hareket hýzý.
    public float sensiivity; // Kamera duyarlýlýðý.
    private Vector2 move, look; // Hareket ve bakýþ yönlerini tutan vektörler.
    private float LookRotation; //Kamera bakýþ açýsýný tutan deðiþken.

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();// Hareket girdisini alýr ve 'move' vektörüne atar.
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>(); //bakýþ girdisini alýr ve 'look' vektörüne atar.
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
