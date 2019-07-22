using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_Door2Script : MonoBehaviour {
    /*
     * --/// By Kevin Ward ///--
     * 
     * The purpose of this script is to open a door through bools and raycasts.
     */


    // Declare Variable
    public bool open = false; // Bool used in Unity Editor to determine if door is open or not. 
    public float door1OpenAngle = 0f; // Angle at which door will be completely open, editable in Unity Editor
    public float door1CloseAngle = 90f; // Angle at which door will be completely closed, editable in Unity Editor
    public float door2OpenAngle = 0f; // Angle at which door will be completely open, editable in Unity Editor
    public float door2CloseAngle = -90f; // Angle at which door will be completely closed, editable in Unity Editor
    public float smooth = 2f; // How fast the door will move
    private GameObject door1;
    private GameObject door2;

    // Use this for initialization
    void Start ()
    {
        door1 = this.transform.Find("HingeParent").gameObject;
        //door1 = GetComponentInChildren<K_Door2HingeReference>();
        //door1 = GameObject.Find("HingeParent");
        /*
        if (door1 != null)
        {
            Debug.Log("Door1 Found");
        }
        if (door1 == null)
        {
            Debug.Log("Door1 not located.");
        }
        */
        door2 = this.transform.Find("HingeParent (1)").gameObject;
        /*
        if (door2 != null)
        {
            Debug.Log("Door2 Found");
        }
        if (door2 == null)
        {
            Debug.Log("Door2 not located.");
        }
        */
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Check if we need to open the doors.
        if (open)
        {
            //Debug.Log("Door is Open");
            Quaternion targetRotationOpen1 = Quaternion.Euler(0, door1OpenAngle, 0); // Rotates door1 along Y Axis
            Quaternion targetRotationOpen2 = Quaternion.Euler(0, door2OpenAngle, 0); // Rotates door2 along Y Axis
            door1.transform.localRotation = Quaternion.Slerp(door1.transform.localRotation, targetRotationOpen1, smooth * Time.deltaTime); // Applies rotation to door1
            door2.transform.localRotation = Quaternion.Slerp(door2.transform.localRotation, targetRotationOpen2, smooth * Time.deltaTime); // Applies rotation to door2

        }

        // Else the door will be closed.
        else
        {
            //Debug.Log("Door is Closed");
            Quaternion targetRotationClose1 = Quaternion.Euler(0, door1CloseAngle, 0); // Rotates door1 along Y Axis
            Quaternion targetRotationClose2 = Quaternion.Euler(0, door2CloseAngle, 0); // Rotates door2 along Y Axis
            door1.transform.localRotation = Quaternion.Slerp(door1.transform.localRotation, targetRotationClose1, smooth * Time.deltaTime); // Applies rotation to door1
            door2.transform.localRotation = Quaternion.Slerp(door2.transform.localRotation, targetRotationClose2, smooth * Time.deltaTime); // Applies rotation to door2
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
