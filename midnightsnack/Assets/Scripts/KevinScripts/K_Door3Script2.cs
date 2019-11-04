using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_Door3Script2 : MonoBehaviour {
    /*
        * --/// By Kevin Ward ///--
        * 
        * The purpose of this script is to play the animation which opens the door and closes the door. 
        */

    // Declare variables
    private Animator anim; // Reference to Animator component
    public bool open = false; // Bool used in Unity Editor to determine if door is open or not. 
    public int index = -1; // Value used in Unity Editor to determine which Key correspondes to this door--0 = unlocked

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>(); // Grabs reference to Animator component attached to this object
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            anim.SetBool("SlidingDoorOpen2", true);
        }

        else
        {
            anim.SetBool("SlidingDoorOpen2", false);
            anim.SetBool("SlidingDoorClose2", true);
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
