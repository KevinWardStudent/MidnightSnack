using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_Lamp1Script : MonoBehaviour {


    /*
     * --/// By Kevin Ward ///--
     * 
     * The purpose of this script is to turn on a lamp through bools and raycasts.
     */


    // Declare Variable
    public bool on = false; // Bool used in Unity Editor to determine if lamp is on or not. 
    private Light lampLight;
    
    // Use this for initialization
    void Start ()
    {
        lampLight = GetComponentInChildren<Light>(); //GetComponent<Light>();

	}
	


	// Update is called once per frame
	void Update ()
    {
        // Check if we need the lamp on
        if (on)
        {
            lampLight.enabled = true;
        }

        else
        {
            lampLight.enabled = false;
        }
	}

    // We use this method to change between states, inverting the bool "on".
    public void ChangeLightState()
    {
        on = !on;
    }
}
