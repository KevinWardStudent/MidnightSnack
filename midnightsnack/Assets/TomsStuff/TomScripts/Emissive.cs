using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emissive : MonoBehaviour
{
    public Material chandelier;
    public Material room;
    public Material bathroom;

    void OnTriggerEnter(Collider other)
    {
        chandelier.EnableKeyword("_EMISSION");
        room.EnableKeyword("_EMISSION");
        bathroom.EnableKeyword("_EMISSION");
    }

    private void OnTriggerExit(Collider other)
    {
        chandelier.DisableKeyword("_EMISSION");
        room.DisableKeyword("_EMISSION");
        bathroom.DisableKeyword("_EMISSION");


    }
}
