using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FirstPersonPlayer.onGround = true;
        PlayerController.onGround = true;
    }
}