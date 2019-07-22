using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSnackSpawn : MonoBehaviour
{
    public GameObject finalSnack;
    public GameObject spawn;
    public GameObject part1;
    public GameObject part2;

    void Update ()
    {
        if (SnackCreator.makeSnack == true)
        {
            Instantiate(finalSnack, transform.position, transform.rotation);
            SnackCreator.makeSnack = false;
            part1.SetActive(false);
            part2.SetActive(false);
        }
    }
}
