using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Timer : MonoBehaviour {

    public static float timer;
    public Text timeCount;

    //private Scene scene;

    void Start()
    {
        //scene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        timer += 1.0f * Time.deltaTime;
        timeCount.text = "Time: " + (int)timer;
    }
}