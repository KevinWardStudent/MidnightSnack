using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_ClockTimerStopScript : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        /*
        * This below if statement of K_PlayerInventory.keys etc checks if the array keys found within K_PlayerInventory returns true.
        * If true, this means the player has "picked up" the appropiate key and the relevant value has been changed in their script to
        * match the appropiate door to which the K_Door1Script is attached to. Because this K_PlayerInventory script needs to work on
        * multiple instances of the same "type" of door, the door1Script index value, which is set by the 
        */
        //K_PlayerInventory.keys[door1Script.index] == true

        //K_PlayerInventory playerInventory = other.transform.parent.GetComponent<K_PlayerInventory>(); // Store K_PlayerInventory in Script Reference
        K_PlayerInventory playerInventory = GetComponent<K_PlayerInventory>();
        K_ClockTime clockScript = GetComponentInChildren<K_ClockTime>(); // Store K_ClockTime in script reference

        //K_PlayerInventory.snacks[];
        if (other.CompareTag("Player") && K_PlayerInventory.snacks[clockScript.index] == true)
        {
            clockScript.StopTime(); // Stop Time. Change Stop Time State on K_ClockTime
        }


        /*
         * Bugs:
         * 
         * K_PlayerInventory has an issue in that the variable its trying to access, snacks, cannot be created as a static variable because then I could not
         * do an object reference as I am doing now. However, what this then means is that this needs to be attached to an object rather than be static.
         * So I'm at an impasse with this because the way in which C# is structured and the way in which I have constucted this means that I cannot
         * continue without restructing the way in which I reference individual code blocks and their variables.
         */
    }
}
