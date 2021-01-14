using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_Footsteps : MonoBehaviour
{
    public GameObject footstep;
    private Rigidbody rb;
    private AudioSource aud;
    public AudioClip footstepClip;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.LeftControl) && rb.velocity.sqrMagnitude > 2f && aud.isPlaying != true)
        {
            Instantiate(footstep, transform.position, transform.rotation);
            aud.PlayOneShot(footstepClip, 0.3f);
        }
    }
}
