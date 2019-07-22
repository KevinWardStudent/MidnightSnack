using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerfLight : MonoBehaviour {

    public GameObject light1;

    bool lightOn;
    //bool lightOff;

    private void Start()
    {
        light1.SetActive(true);
        lightOn = true;
        //lightOff = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("nerf") && !lightOn)
        {
            light1.SetActive(true);
            lightOn = true;
        }
        else if(other.gameObject.CompareTag("nerf") && lightOn)
        {
            light1.SetActive(false);
            lightOn = false;
        }
    }
}
