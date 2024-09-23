using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimerText;
    float ElapsedTime; //Ge�en s�re 

    private void Update()
    {// durdurma i�lemi i�in de kodlar eklenecek...
        ElapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(ElapsedTime / 60); //Ge�en dakikay� bulmak i�in 
        int seconds = Mathf.FloorToInt(ElapsedTime % 60); //Ge�en saniyeyi bulmak i�in
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
