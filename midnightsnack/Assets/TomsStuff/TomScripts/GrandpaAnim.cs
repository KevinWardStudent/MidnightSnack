using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandpaAnim : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    public bool Walk;
    public bool Looking;
    public bool Pickup;
    public bool Dance;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        //Dancing
        if (Input.GetButtonDown("Dance"))
        {
            anim.SetBool("Dance", true);
        }
        else if(Input.GetButtonUp("Dance"))
        {
            anim.SetBool("Dance", false);
        }

        //Looking
        if (Input.GetButtonDown("Looking"))
        {
            anim.SetBool("Looking", true);
        }
        else
        {
            anim.SetBool("Looking", false);
        }

        //Pickup
        if (Input.GetButtonDown("Pickup"))
        {
            anim.SetBool("Pickup", true);
        }
        else
        {
            anim.SetBool("Pickup", false);
        }

        //Walking
        if (Input.GetButtonDown("Horizontal"))
        {
            anim.SetBool("Walk", true);
        }
        else if (Input.GetButtonUp("Horizontal"))
        {
            anim.SetBool("Walk", false);
        }
        if (Input.GetButtonDown("Vertical"))
        {
            anim.SetBool("Walk", true);
        }
        else if (Input.GetButtonUp("Vertical"))
        {
            anim.SetBool("Walk", false);
        }
    }
}
