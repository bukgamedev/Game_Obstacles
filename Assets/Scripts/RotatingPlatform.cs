using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{

    public float rotationSpeed = 30f;

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Sadece "Player" etiketli objelerle etkile�ime girsin
        if (collision.gameObject.CompareTag("Player"))
        {
            // Karakteri platforma ba�la
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Etkile�im sona erdi�inde karakterin platformdan ayr�lmas�n� sa�la
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}

