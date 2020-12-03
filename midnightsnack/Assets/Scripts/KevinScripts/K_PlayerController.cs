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
     * Here we store the camera attached to the player as the "Head". In the past I've made a seperate game object, but 
     * 
     * How does Interaction work technically?
     * 
     * Interaction works through Raycasts. This Raycast originates from the currently selected camera. For purposes of simplicity, the first build of this was done on a
     * first person camera setup and was modified later to suit mechanics which allow for a switch between two cameras. After we establish the origin point of the ray, presumably
     * the center of the camera/screen. Then after this the Ray will shoot out with the camera's transform in a forward direction. The colliding data will then be stored in a
     * variable called hit and we will also establish a range for this raycast. 5ft sounds good to me. This range will define, the range at which the player can interact with an object.
     * 
     * 
     * 
     */

    // Declare Variables

    private Rigidbody rb; // References to Rigidbody Component
    public float movementSpeed; // Assigned in Unity Editor, Speed at which player moves
    public float lookSpeed; // Assigned in Unity Editor, Speed at which player looks
    private Camera fpsCam; // Camera attached to this object 
    float xAxisClamp; // Float value to determine the mximum distance the player can look up or down while rotating on the x axis
    float xAxisClampXbox; // Xbox version of above code
    float zAxisClamp; // Float value to determine the maximum distance the player "leans" aka rotate on the z axis

    public bool lockCam;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Grabs reference attached to Player's Rigidbody component
        Cursor.lockState = CursorLockMode.Locked; // Locks mouse to center of screen
        Cursor.visible = false; // Hides the Mouse Cursor while the game is playing
        fpsCam = GetComponentInChildren<Camera>(); // Grabs reference to Main Camera component attached to Player 
        xAxisClamp = 0.0F; // This clamp is set to 0 by default so that the Camera attached to the head does not oscilate when colliding with other objects.
        zAxisClamp = 0.0F; // This clamp is set to 0 by default so that the Camera is center and is not at some other position, this value is incrimented by the player moving the mouse
    }

    void FixedUpdate()
    {
        // Movement Inputs Assigned
        float moveVertical = Input.GetAxisRaw("Vertical");
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        // Movement Function
        Vector3 movementInput = new Vector3(moveHorizontal, 0.0F, moveVertical);
        rb.velocity = transform.TransformDirection(movementInput) * movementSpeed; // Translates local spcae of values fed into velocity into world space coordinates

        // Look Inputs Assigned
        float lookHorizontal = Input.GetAxis("Mouse X"); // Mouse Left Right
        float lookVertical = Input.GetAxis("Mouse Y"); // Mouse Up Down

        // Look Functions
        transform.Rotate(Vector3.up * lookHorizontal); // rotates Torso left right--Used for Looking Left Right
        fpsCam.transform.Rotate(Vector3.left * lookVertical);

        xAxisClamp += lookVertical;

        if (xAxisClamp > 90.0F)
        {
            xAxisClamp = 90.0F;
            lookVertical = 0.0F;
            ClampXAxisRotationToValue(270.0F);

        }
        else if (xAxisClamp < -90.0F)
        {
            xAxisClamp = -90.0F;
            lookVertical = 0.0F;
            ClampXAxisRotationToValue(90.0F);
        }
        if (zAxisClamp > 15.0F)
        {
            zAxisClamp = 15.0F;
            ClampZAxisRotationToValue(-15.0F);
        }
        else if (zAxisClamp < -15.0F)
        {
            zAxisClamp = -15.0F;
            ClampZAxisRotationToValue(15.0F);
        }

    }
    // Below methods are related to Axis Clamping and set to the value fed in when the methods are called above
    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = fpsCam.transform.eulerAngles;
        eulerRotation.x = value;
        fpsCam.transform.eulerAngles = eulerRotation;
    }
    private void ClampZAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.z = value;
        transform.eulerAngles = eulerRotation;
    }
}