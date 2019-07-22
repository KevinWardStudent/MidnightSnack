using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_Door1Script : MonoBehaviour {


    /*
     * --/// By Kevin Ward ///--
     * 
     * The purpose of this script is to open a door through bools and raycasts.
     * A secondary modification was added on 7/14/19 to allow for this script to
     * be modular with key objects and also make it eaiser on the Level Designer.
     * Note that the index value of the door determines which key will door it opens.
     * 0 by default is an unlocked door. -1 is the value used to indicate to the Level Designer
     * that the value attached to the door needs to be modified to hold a number which will
     * be accepted in the array of keys in the game
     */


    // Declare Variables
    public bool open = false; // Bool used in Unity Editor to determine if door is open or not. 
    public float doorOpenAngle = 90; // Angle at which door will be completely open, editable in Unity Editor
    public float doorCloseAngle = 0f; // Angle at which door will be completely closed, editable in Unity Editor
    public float smooth = 2f; // How fast the door will move

    public int index = -1; // Value used in Unity Editor to determine which Key correspondes to this door--0 = unlocked

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Check if we need to open the door.
        if (open)
        {
            //Debug.Log("Door1 Open");
            Quaternion targetRotationOpen = Quaternion.Euler(0, -doorOpenAngle, 0); // Rotates door along Y Axis
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime); // Applies rotation to door

        }

        // Else the door will be closed.
        else
        {
            //Debug.Log("Door1 Closed");
            Quaternion targetRotationClose = Quaternion.Euler(0, doorCloseAngle, 0); // Rotates door along Y Axis
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationClose, smooth * Time.deltaTime); // Applies rotation to door
        }
	}

    /*
     * We use this below method invert the bool "Open" so that we change the state of the door.
     */
    public void ChangeDoorState()
    {
        open = !open;
    }
}
