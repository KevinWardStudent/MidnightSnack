using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ClockTime : MonoBehaviour
{
    public TMP_Text timerText;
    private float time = 0;


    void Start()
    {
        StartTime();
    }

    void StartTime()
    {
        if (timerText != null)
        {
            time = 0;
            InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
        }
    }

    void UpdateTimer()
    {
        if (timerText != null)
        {
            time += Time.deltaTime;
            string hours = Mathf.Floor(time / 3600).ToString("12 ");
            string minutes = Mathf.Floor(time / 60).ToString("00");
            timerText.text = hours + minutes;
        }
    }
}

    
   

    
