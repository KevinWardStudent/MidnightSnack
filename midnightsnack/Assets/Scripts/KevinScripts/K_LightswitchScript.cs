using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_LightswitchScript : MonoBehaviour {

    /*
    * --/// By Kevin Ward ///--
    * 
    * The purpose of this script is to turn on all lamps in a room through bools and raycasts.
    */


    // Declare Variables
    public bool on = false; //Bool used in the Unity Editor to determine if the lights in the room are on
    //private GameObject[] roomLamps; // Array used to store all game object of type "Lamp"
    private Light[] roomLights; // Array used to store all lights attached to the lightswitch game object
    
    // Use this for initialization
    void Start ()
    {
        roomLights = GetComponentsInChildren<Light>(); // Stores all lights attached to Children in inside of the array roomLights
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Check if we need the roomLights on
        if (on)
        {
            // We need to enable each light individually
            for (int i = 0; i < roomLights.Length ; i++)
            {
                roomLights[i].enabled = true;
            }
        }

        else
        {
            // We need to disable each light individually
            for (int i = 0; i < roomLights.Length; i++)
            {
                roomLights[i].enabled = false;
            }
        }
    }
    /*
     * We use this below mehtod to invert the bool "On" 
     */
    public void ChangeLightswitchState()
    {
        //Debug.Log("You Rang?");
        on = !on;
    }
}
