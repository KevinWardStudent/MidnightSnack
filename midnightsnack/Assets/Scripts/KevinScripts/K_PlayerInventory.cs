using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_PlayerInventory : MonoBehaviour {


    /*
     * --/// By Kevin Ward ///--
     * 
     * The purpose of this script is to store the values of inventory items the player "has"
     * that are not critical to the objectives the player must picked up to interact with objects like doors or safes.
     */

    public static bool[] keys = new bool[5]; // This array will store all of our key values, originally the amount bools stored in the array was 5, but the Level Designer can change

    void Start()
    {
        keys[0] = true; // A default value which will act as the "unlocked" door value, set each door in the scene to have this index value to be considered an "unlocked" door
    }
}
