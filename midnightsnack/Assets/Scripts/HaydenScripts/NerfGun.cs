using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerfGun : MonoBehaviour {

    public float throwForce = 1f;
    public GameObject bullet;
    public GameObject spawn;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject shot = Instantiate(bullet, spawn.transform.position, spawn.transform.rotation);
        Rigidbody rb = shot.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        Destroy(shot, 1.2f);
    }
}
