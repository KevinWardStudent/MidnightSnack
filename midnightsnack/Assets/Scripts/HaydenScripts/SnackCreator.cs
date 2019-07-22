using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnackCreator : MonoBehaviour
{
    //public GameObject finalSnack;
    //public GameObject spawn;

    public static bool makeSnack;

    private void Start()
    {
        makeSnack = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("otherpart"))
        {
            makeSnack = true;
            //Debug.Log("makeSnack = true");
            //finalSnack.SetActive(true);
            //Instantiate(finalSnack, spawn.transform);
            //other.gameObject.SetActive(false);
            //gameObject.SetActive(false);
        }
    }
}
