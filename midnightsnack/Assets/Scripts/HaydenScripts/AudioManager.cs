using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static bool playShot2;
    public static bool playDash;

    public AudioClip shot2;
    public AudioClip dash;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (playShot2)
        {
            audioSource.PlayOneShot(shot2, .7f);
            playShot2 = false;
        }
        if (playDash)
        {
            audioSource.PlayOneShot(dash, .7f);
            playDash = false;
        }
    }
}
