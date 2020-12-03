using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliAnim : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    public bool isWalking;
    public bool isCrouching;
    public bool isJumping;
    public bool isReloading;
    public bool isTouch;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        //Crouching
        if (Input.GetButtonDown("Crouch"))
        {
            anim.SetBool("isCrouching", true);
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            anim.SetBool("isCrouching", false);
        }

        //Jumping
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

        //Reloading
        if (Input.GetButtonDown("Reload"))
        {
            anim.SetBool("isReloading", true);
        }
        else
        {
            anim.SetBool("isReloading", false);
        }

        //Interacting
        if (Input.GetButtonDown("Touch"))
        {
            anim.SetBool("isTouch", true);
        }
        else
        {
            anim.SetBool("isTouch", false);
        }

        //Walking
        if (Input.GetButtonDown("Horizontal"))
        {
            anim.SetBool("isWalking", true);
        }
        else if (Input.GetButtonUp("Horizontal"))
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetButtonDown("Vertical"))
        {
            anim.SetBool("isWalking", true);
        }
        else if (Input.GetButtonUp("Vertical"))
        {
            anim.SetBool("isWalking", false);
        }
    }
}
