using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_2 : MonoBehaviour
{
    public Rigidbody rb; //Karakterin Rigidbody Componenti.
    public GameObject CameraHolder; //Karakterin çocugu olan kamera tutucu objesi.
    public float speed; // Karakterin hareket hýzý.
    public float sensitivity; // Kamera duyarlýlýðý.
    public float MaxForce; // Kamera duyarlýlýðý.
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
    public void OnJump(InputAction.CallbackContext context)
    {
        Jump();
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Jump()
    {

    }
    void Move()
    {
        Vector3 CurrentVelocity = rb.velocity; // Karakterin mevcut hýzýný alýr.
        Vector3 TargetVelocity = new Vector3(move.x, 0, move.y); // Hareket girdisinden hedef hýzý oluþturur.
        TargetVelocity *= speed; // Hedef hýzý karakterin hareket hýzý ile çarpar.
        TargetVelocity = transform.TransformDirection(TargetVelocity); // Hedef hýzý dünya koordinatlarýna dönüþtürür.
        Vector3 VelocityChange = (TargetVelocity - CurrentVelocity);// Mevcut hýz ile hedef hýz arasýndaki farký hesaplar.
        VelocityChange = new Vector3(VelocityChange.x,0,VelocityChange.z); //karakterin direkt olarak düþmesini saðladým.
        Vector3.ClampMagnitude(VelocityChange, MaxForce);// Hýz deðiþimini maksimum kuvvetle sýnýrlar.
        rb.AddForce(VelocityChange, ForceMode.VelocityChange);// Rigidbody'ye hýz deðiþimini uygular.
    }
    void Look()
    {
        //Dönüþ için
        transform.Rotate(Vector3.up * look.x * sensitivity);

        //Bakýþ için
        LookRotation += (-look.y * sensitivity);
        LookRotation = Mathf.Clamp(LookRotation, -90, 90); //Kameranýn bakýþ açýlarýný sýnýrlamak için.
        CameraHolder.transform.eulerAngles = new Vector3(LookRotation, CameraHolder.transform.eulerAngles.y, CameraHolder.transform.eulerAngles.z);

    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Look();
    }
}