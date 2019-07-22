using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_DoorKnobAnimPlayer : MonoBehaviour {

    /*
     * --/// By Kevin Ward ///--
     * 
     * The purpose of this script is to play the animation of the doorknob rotating when the door is activated. 
     */

    // Declare variables
    private Animator anim; // Reference to Animator component
    
    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>(); // Grabs reference to Animator component attached to this object
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PlayAnimation()
    {
        anim.Play("DoorKnobOpen");
        //anim.Play("DoorKnobClose");
        /*
        anim.SetBool("DoorKnobOpen", true); // Set Control Flag for animation true to begin
        anim.SetBool("DoorKnobOpen", false); // Set Control Flag for animation false to end
        anim.SetBool("DoorKnobClose", true); // Set Control Flag for animation true to begin
        anim.SetBool("DoorKnobClose", false); // Set Control Flag for animation false to end
        */
        //StartCoroutine(PlayAnimationCorotuine());
    }

    /*
    IEnumerator PlayAnimationCorotuine()
    {
        anim.SetBool("DoorKnobOpen", true); // Set Control Flag for animation true to begin
        yield return new WaitForSeconds(anim.GetComponent<Animation>().clip.length);
        anim.SetBool("DoorKnobOpen", false); // Set Control Flag for animation false to end
        anim.SetBool("DoorKnobClose", true); // Set Control Flag for animation true to begin
        anim.SetBool("DoorKnobClose", false); // Set Control Flag for animation false to end
    }
    */
}
