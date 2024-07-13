using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JumpPad : MonoBehaviour
{
    public float JumpPower = 1f; //Zýplatma gücü
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController characterController = other.GetComponent<CharacterController>();
            if (characterController != null)
            {
                StartCoroutine(ApplyJump(characterController));
            }
        }
    }
    private IEnumerator ApplyJump(CharacterController characterController)
    {
        float elapsedTime = 0f;
        float duration = 0.1f; // Harekete ne kadar süre boyunca kuvvet uygulanacak

        while (elapsedTime < duration)
        {
            characterController.Move(Vector3.up * JumpPower * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}