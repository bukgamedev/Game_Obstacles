using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI TimerText;
    float ElapsedTime; //Geçen süre 

    private void Update()
    {
        ElapsedTime = Time.deltaTime;
        TimerText.text = ElapsedTime.ToString();
    }
}
