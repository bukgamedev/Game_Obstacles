using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public float ElapsedTime; //Ge�en s�re 

    private void Update()
    {
        ElapsedTime = Time.deltaTime;
        TimerText.text = ElapsedTime.ToString();
    }
}
