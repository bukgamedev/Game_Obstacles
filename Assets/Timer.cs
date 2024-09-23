using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimerText;
    float ElapsedTime; //Geçen süre 

    private void Update()
    {// durdurma iþlemi için de kodlar eklenecek...
        ElapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(ElapsedTime / 60); //Geçen dakikayý bulmak için 
        int seconds = Mathf.FloorToInt(ElapsedTime % 60); //Geçen saniyeyi bulmak için
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
