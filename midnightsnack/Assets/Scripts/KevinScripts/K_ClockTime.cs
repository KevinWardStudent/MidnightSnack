using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class K_ClockTime : MonoBehaviour {



    /*
     * Working clock, needs additions tom wanted
     *
     * Corresponds to a victory state
     * Victory State achieved in way similar to finding key, but with a collider
     * Acts as a timer for the player in finding the snack
     * Additional features
     * Works in Military time and can alternate between states with bool
     */
    public GameObject clockCanvas;
    public Text clockTimeText;
    public float hour;
    public float minute;

    public bool stop = false; // Controls when clock should be stopped, by default false
    public int index = -1;  // This value is set in the Unity Editor and sets which door's index this instance of the clock

    // Update is called once per frame
    void Update ()
    {
        // This is for if the camera is attached to a canvas which does not use world space
        //Vector3 textPos = Camera.main.WorldToScreenPoint(this.transform.position);
        //clockTimeText.transform.position = textPos;

        //Attempt #2
        clockTimeText.transform.position = this.transform.position;
        clockTimeText.transform.rotation = this.transform.rotation;


        //Attempt#3
        //clockCanvas.transform.position = this.transform.position;
        if (!stop)
        {
            minute += 1.0f * Time.deltaTime;
            if (minute >= 60)
            {
                hour++;
                minute = 0.0f;
            }
            if (hour > 12)
            {
                hour = 1;
            }

            if (hour < 10 && minute > 10)
            {
                clockTimeText.text = "0" + (int)hour + ":" + (int)minute;
            }
            else if (hour >= 10 && minute < 10)
            {
                clockTimeText.text = (int)hour + ":" + "0" + (int)minute;
            }
            else if (hour < 10 && minute < 10)
            {
                clockTimeText.text = "0" + (int)hour + ":" + "0" + (int)minute;
            }
            else
            {
                clockTimeText.text = (int)hour + ":" + (int)minute;
            }

            /*
             * Other Code
             * 
             * In Variables:
             * 
             * public Text clockTimeText;
             * private float startTime;
             * public float hour;
             * public float minute;
             * 
             * In Start()
             * 
             * void Start()
             * {
             *      startTime = Time.time;
             * }
             * 
             * In Update()
             * 
             * void Update()
             * {
             *      float t = Time.time - startTime;
             *      
             *      string minutes = ((int) t / 60).ToString();
             *      string seconds = (t % 60).ToString("f2");
             *      
             *      clockTimeText.text = minutes + ":" + seconds;
             * }
             */
        }
    }

    public void StopTime()
    {
        stop = !stop; // Change state of stop, to stop time
    }
}
