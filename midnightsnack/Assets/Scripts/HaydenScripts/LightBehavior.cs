using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehavior : MonoBehaviour
{
    public GameObject exposedLight;
    public GameObject noLight;

	void Update ()
    {
        if (!(exposedLight.activeSelf))
        {
            noLight.SetActive(true);
        }
    }
}
