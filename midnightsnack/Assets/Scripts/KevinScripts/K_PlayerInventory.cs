using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_PlayerInventory : MonoBehaviour {


    /*
     * --/// By Kevin Ward ///--
     * 
     * The purpose of this script is to store the values of inventory items the player "has" that are either
     * not critical to the player's objectives must picked up to interact with objects (i.e. like doors or safes) or
     * are also critical to the objectives the player. In short this a hidden inventory which can be used to determine obejctives.
     * 
     * First we tackle keys, which are stored in an array and is modular to all instances of the its prefab. The same course follows
     * for all objects which are created in this script.
     * 
     */

    public static bool[] keys = new bool[5]; // This array will store all of our key values, originally the amount bools stored in the array is 5, but the Level Designer can change it according to the situation
    public static bool[] snacks = new bool[5]; // This array will store all of our snack values, orginally the amount bools stored in the array is 5, but the Level Designer can change it according to the situation
    // Changed above to non static array so that it can be used in an instance reference later in K_ClockTimerStopScript-- this does not work.

    void Start()
    {
        keys[0] = true; // A default value which will act as the "unlocked" door value, set each door in the scene to have this index value to be considered an "unlocked" door
    }
}
