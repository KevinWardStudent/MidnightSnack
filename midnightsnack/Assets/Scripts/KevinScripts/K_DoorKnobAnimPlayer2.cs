using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_DoorKnobAnimPlayer2 : MonoBehaviour {


    /*
     * --/// By Kevin Ward ///--
     * 
     * The purpose of this script is to play the animation of the doorknob rotating when the door is activated. 
     */

    // Declare variables
    private Animator anim; // Reference to Animator component

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>(); // Grabs reference to Animator component attached to this object
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAnimation()
    {
        anim.Play("DoorKnobOpen2");
    }
}
