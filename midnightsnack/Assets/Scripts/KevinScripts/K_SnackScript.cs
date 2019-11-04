using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_SnackScript : MonoBehaviour {

    /*
    * --/// By Kevin Ward ///--
    * 
    * This script is attached the snack game object, this script functions almost identically to the key in that each snack is an
    * instance in which is contained one int index value. This value by default is -1 a value which is not supported by the game, so the
    * level designer must change this so that the value will be matched with the index of the clock to which this value matches. It is
    * set up this way so that multiple clocks can be placed so that in the case of each snack being acquired, each clock will correspond to that
    * snack individually, providing a digetic way of the player keeping track of the time passed for picking up each snack.
    */

    // Declare Variables
    public int index = -1; // This value is set in the Unity Editor and sets which door's index this instance of the snack
}
