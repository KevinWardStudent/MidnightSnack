using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_ClosetScript : MonoBehaviour {

    /*
   * --/// By Kevin Ward ///--
   * 
   * The purpose of this script is to set the player's location to the "spawn" or "HidePoint" attached to this cloest.
   * 
   * Pesudo-Code
   * The player approaches the door.
   * The player LMB clicks casting a ray at the door.
   * This acesses a method stored within K_ClosetScript.
   * This method will change a state within this script because there are only two logical outcomes to the problem.
   * 
   * 
   */

    // Declare Variables
    public bool isHiding = false; // Player is not hiding until th
    
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isHiding)
        {

        }
        else
        {

        }
	}

    /*
     * We use this below method to change the state of this mechanic to is not hiding to is hiding. From then on the player is inside the closet.
     */
    public void ChangeHideState()
    {
        isHiding = !isHiding; // Change hiding
    }
}
