﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockToTarget : MonoBehaviour
{

    public GameObject target;

	void FixedUpdate ()
    {
        transform.position = target.transform.position;
	}
}
