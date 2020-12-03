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
    [SerializeField]
    public List<GameObject> roomLights = new List<GameObject>();
	
	// Update is called once per frame
	void Update ()
    {

        if (on == false)
        {
            for (int i = 0; i < roomLights.Count; i++)
            {
               roomLights[i].GetComponent<K_Lamp1Script>().on = false;
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
        for (int i = 0; i < roomLights.Count; i++)
        {
            roomLights[i].GetComponent<K_Lamp1Script>().ChangeLightState();
        }
    }
}
