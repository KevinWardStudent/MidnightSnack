using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_PlayerController : MonoBehaviour {

    /*
     * --/// By Kevin Ward ///--
     * 
     * The purpose of this script is to allow the player character to both move and rotate using:
     * 
     * W: Forward
     * A: Strafe Left
     * D: Strafe Right
     * S: Backward
     * 
     * Mouse: Look
     * 
     * Note: I tend to write my code explicitly and my explainations lengthy just so I don't confuse you, but also myself at 4am.
     * Feel free to ignore the greentext.
     * 
     * FAQs
     * 
     * How does movement work technically?
     * 
     * Movement works first through establishing input through the default inputs found in Unity's Input Axes found within Edit/ProjectSettings/Input.
     * 'W' and 'S' are assigned to the "Vertical" axis of the Inputs. 'A' and 'D' are assigned to the "Horizontal" axis of Inputs. These inputs will
     * change over time as the player moves around the world space. The total input of an axis ranges from -1 to 1, with positve numbers being considered a
     * "forward" input and negative being considered a "negative" input.
     * 
     * 
     * How does look work technically?
     * 
     * 
     */

    // Declare Variables

    private float movementSpeed; // Speed of object this script is attached to, i.e. player

    void Start()
    {

    }

    void FixedUpdate()
    {
        // Movement Inputs Assigned
        float moveVertical = Input.GetAxisRaw("Vertical");
        float moveHorizontal = Input.GetAxisRaw("Horizontal");


    }
}