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
    public bool isHiding = false; // Player is not hiding until they activate the method ChangeHidingState();
    public GameObject hidingSpotPos; // The position to which the player game object is set to when they are "hiding"
    public GameObject notHidingSpotPos; // The positon to which the player game object is set to when they are "not hiding"
    private GameObject player; // Reference to player gameObject
    public bool hasHid = false; // Control Flag to determine if the player has hid before
    
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*
        Ray rayInteract = new Ray(transform.position, transform.forward); // Fires ray out from Camera position forward on the z axis
        RaycastHit hit; // Stores info of object ray hits
        Physics.Raycast(rayInteract, out hit, 3.0F);
        */
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isHiding) // If colliding gameObject is tagged as player
        {
            Debug.Log("Player is here!");
            //other.gameObject.transform.position = hidingSpotPos.transform.position; // Set player position to hidingSpotPos --Bug-- Player faces wrong direction because this is the value of the worldspace
            //other.gameObject.transform.position = Vector3.Slerp(other.gameObject.transform.position, hidingSpotPos.transform.position, 0.05f); // Moves player between point a and b, at a given rate, not what I wanted
            other.gameObject.transform.position = hidingSpotPos.transform.position; // set player position to hidingSpotPos
            other.gameObject.transform.rotation = hidingSpotPos.transform.rotation; //Quaternion.Euler(0.0F, 180.0F, 0.0F); // Rotate player around to face outside closet
            //Camera fpsCam = other.gameObject.GetComponent<Camera>();
            //float lookHorizontal = Input.GetAxis("Mouse X");
            //other.gameObject.transform.Rotate(Vector3.down * lookHorizontal); // rotates Torso left right--Used for Looking Left Right
            //other.gameObject.transform.rotation = new Quaternion();
            hasHid = true;
        }
        else if (hasHid && other.gameObject.CompareTag("Player") && !isHiding)
        {
            other.gameObject.transform.position = notHidingSpotPos.transform.position; // Set Player position to notHidingSpotPos
            other.gameObject.transform.rotation = notHidingSpotPos.transform.rotation; // Set Player rotation to notHidingSpotPos
            hasHid = false;
            // Free Player from position to outside spot

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
