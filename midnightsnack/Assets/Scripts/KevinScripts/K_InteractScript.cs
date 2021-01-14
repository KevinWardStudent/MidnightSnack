using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_InteractScript : MonoBehaviour {

    /*
     * --/// By Kevin Ward ///--
     * 
     * The purpose of this script is to allow interaction between the player and different objects.
     * This is done through the player pressing the Left Mouse Button, which in turn creates a ray to
     * shot from the center of the camera's position, in the direction of the z axis. (Forward, basically).
     * Then we store the information returned from the object the ray impacts inside a RaycastHit variable
     * called Hit. Then if we hit something with our ray, we store the data so long as it is within interact distance.
     * 
     * Note that this script is to placed on all characters which will be played by users. This script is listed in order
     * according to the version of the item and the subsequent versions of it after words. So Door1 then Door1Locked, etc.
     */


    // Declare Variables
    public float interactDistance = 2.0f; // Distance at which objects can be interacted with
    bool animPlay = false; // Control Flag to check if we have already played the animation tied to the object

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray rayInteract = new Ray(transform.position, transform.forward); // Fires ray out from Camera position forward on the z axis
            RaycastHit hit; // Stores info of object ray hits
            if (Physics.Raycast(rayInteract, out hit, interactDistance))
            {
                Debug.DrawLine(transform.position,hit.transform.position);
                Debug.Log(hit.transform.name); // Prints name of collided object
                if (hit.collider.CompareTag("Door1") && !animPlay)
                {
                    K_Door1Script door1Script = hit.collider.transform.parent.GetComponent<K_Door1Script>(); // Store the hit variable in script ref object for readability
                    K_DoorKnobAnimPlayer door1ScriptAnim = hit.collider.transform.GetComponentInChildren<K_DoorKnobAnimPlayer>(); // Store the hit variable in script ref object for readability

                    /*
                     * This below if statement of K_PlayerInventory.keys etc checks if the array keys found within K_PlayerInventory returns true.
                     * If true, this means the player has "picked up" the appropiate key and the relevant value has been changed in their script to
                     * match the appropiate door to which the K_Door1Script is attached to. Because this K_PlayerInventory script needs to work on
                     * multiple instances of the same "type" of door, the door1Script index value, which is set by the 
                     */

                    if (K_PlayerInventory.keys[door1Script.index] == true)
                    {
                        door1Script.ChangeDoorState(); // Call ChangeDoorState by accessing, the parent of the door and its script
                        door1ScriptAnim.PlayAnimation(); // Play Doorknob Turning Animation from Hit
                        animPlay = !animPlay; // Animation Play invert the bool, reset upon call of this statement
                    }
                }
                else if (hit.collider.CompareTag("Door1") && animPlay)
                {
                    hit.collider.transform.parent.GetComponent<K_Door1Script>().ChangeDoorState(); // Call ChangeDoorState by accessing, the parent of the door and its script
                    animPlay = !animPlay; // Animation Play invert the bool, reset upon call of this statement

                }
                if (hit.collider.CompareTag("Door2") && !animPlay)
                {
                    K_Door2Script door2Script = hit.collider.transform.GetComponent<K_Door2Script>(); // Store the hit variable in script ref object for readability
                    K_DoorKnobAnimPlayer door2ScriptAnim = hit.collider.transform.GetComponentInChildren<K_DoorKnobAnimPlayer>(); //Store the hit variable in script ref object for readability
                    K_DoorKnobAnimPlayer2 door2ScriptAnim2 = hit.collider.transform.GetComponentInChildren<K_DoorKnobAnimPlayer2>(); // Store the hit variable in script ref object for readility

                    if (K_PlayerInventory.keys[door2Script.index] == true)
                    {
                        door2Script.ChangeDoorState(); // Call ChangeDoorState by accessing, the parent of the door and its script
                        door2ScriptAnim.PlayAnimation(); // Play the DoorKnob Turning Animation from Hit
                        door2ScriptAnim2.PlayAnimation(); // Play the DoorKnob Turning Animation from Hit
                        animPlay = !animPlay; // Animation Play invert the bool, reser upon call of this statement
                    }
                    /*
                    hit.collider.transform.GetComponent<K_Door2Script>().ChangeDoorState(); // Call ChangeDoorState by acessing, the parent of the doors and its script 
                    hit.collider.transform.GetComponentInChildren<K_DoorKnobAnimPlayer>().PlayAnimation(); // Play Doorknob Turning Animation from Hit
                    hit.collider.transform.GetComponentInChildren<K_DoorKnobAnimPlayer2>().PlayAnimation(); // Play Doorknob Turning Animation from Hit
                    animPlay = !animPlay; // Animation Play invert the bool, reset upon call of this statement
                    */
                }
                else if (hit.collider.CompareTag("Door2") && animPlay)
                {
                    hit.collider.transform.GetComponent<K_Door2Script>().ChangeDoorState(); // Call ChangeDoorState by acessing, the parent of the doors and its script
                    animPlay = !animPlay; // Animation Play invert the bool, reset upon call of this statement
                }
                if (hit.collider.CompareTag("Door3") && animPlay)
                {
                    K_Door3Script door3Script = hit.collider.transform.GetComponent<K_Door3Script>(); // Store the hit variable in script ref object for readability

                    if (K_PlayerInventory.keys[door3Script.index] == true)
                    {
                        door3Script.ChangeDoorState(); // Call ChangeDoorState by acessing, the parent of the doors and its script
                        animPlay = !animPlay; // Animation Play invert the bool, reset upon call of this statement
                    }
                    
                    /*
                    hit.collider.transform.GetComponent<K_Door3Script>().ChangeDoorState(); // Call ChangeDoorState by acessing, the parent of the doors and its script
                    animPlay = !animPlay; // Animation Play invert the bool, reset upon call of this statement
                    */
                }
                else if (hit.collider.CompareTag("Door3") && !animPlay)
                {
                    hit.collider.transform.GetComponent<K_Door3Script>().ChangeDoorState(); // Call ChangeDoorState by acessing, the parent of the doors and its script
                    animPlay = !animPlay; // Animation Play invert the bool, reset upon call of this statement
                }
                if (hit.collider.CompareTag("Door3_2") && animPlay)
                {
                    K_Door3Script2 door3Script2 = hit.collider.transform.GetComponent<K_Door3Script2>(); // Store the hit variable in script ref object for readability

                    if (K_PlayerInventory.keys[door3Script2.index] == true)
                    {
                        door3Script2.ChangeDoorState(); // Call ChangeDoorState by acessing, the parent of the doors and its script
                        animPlay = !animPlay; // Animation Play invert the bool, reset upon call of this statement
                    }
                    /*
                    hit.collider.transform.GetComponent<K_Door3Script2>().ChangeDoorState(); // Call ChangeDoorState by acessing, the parent of the doors and its script
                    animPlay = !animPlay; // Animation Play invert the bool, reset upon call of this statement
                    */
                }
                else if (hit.collider.CompareTag("Door3_2") && !animPlay)
                {
                    hit.collider.transform.GetComponent<K_Door3Script2>().ChangeDoorState(); // Call ChangeDoorState by acessing, the parent of the doors and its script
                    animPlay = !animPlay; // Animation Play invert the bool, reset upon call of this statement
                }
                if (hit.collider.CompareTag("Door4") && animPlay)
                {
                    K_Door4Script door4Script = hit.collider.transform.GetComponent<K_Door4Script>(); // Store the hit variable in script ref object for readability

                    if (K_PlayerInventory.keys[door4Script.index] == true)
                    {
                        door4Script.ChangeDoorState(); // Call ChangeDoorState by acessing, the parent of the doors and its script
                        animPlay = !animPlay; // Animation Play invert the bool, reset upon call of this statement
                    }
                }
                else if (hit.collider.CompareTag("Door4") && !animPlay)
                {
                    hit.collider.transform.GetComponent<K_Door4Script>().ChangeDoorState(); // Call ChangeDoorState by acessing, the parent of the doors and its script
                    animPlay = !animPlay; // Animation Play invert the bool, reset upon call of this statement
                }
                if (hit.collider.CompareTag("Key"))
                {
                    K_PlayerInventory.keys[hit.collider.GetComponent<K_KeyScript>().index] = true; // Set the value of K_PlayerInventory to the value of the key
                    Destroy(hit.collider.gameObject); // Destroy the key
                }
                if (hit.collider.CompareTag("Lamp1"))
                {
                    hit.collider.transform.GetComponent<K_Lamp1Script>().ChangeLightState(); // Call ChangeLightState by accessing, the parent of light and its script
                }
                if (hit.collider.CompareTag("Lightswitch"))
                {
                    //Debug.Log("Flick! Lights.");
                    hit.collider.transform.GetComponent<K_LightswitchScript>().ChangeLightswitchState(); // Call ChangeLightSwitchState by accessing, the script attached to Lightswitch
                }
                if (hit.collider.CompareTag("Closet"))
                {
                    hit.collider.transform.parent.GetComponent<K_ClosetScript>().ChangeHideState(); // Call ChangeHideState by accessing the script attached to Closet
                }

                if (hit.collider.CompareTag("Snack"))
                {
                    K_PlayerInventory.keys[hit.collider.GetComponent<K_SnackScript>().index] = true; // Set the value of the K_PlayerInventory to the value of the snack
                    Destroy(hit.collider.gameObject); // Destroy the snack
                }
                if (hit.collider.CompareTag("Clock"))
                {
                    //If the collided object is a clock
                    if (K_PlayerInventory.keys[hit.collider.GetComponent<K_SnackScript>().index] == true) { }
                }
            }
        }
	}
}
