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
        // Sadece "Player" etiketli objelerle etkileþime girsin
        if (collision.gameObject.CompareTag("Player"))
        {
            // Karakteri platforma baðla
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Etkileþim sona erdiðinde karakterin platformdan ayrýlmasýný saðla
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}

