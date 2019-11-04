using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerfGun : MonoBehaviour
{
    public static float ammo;
    public float lastFired;
    public float fireRate;
    public float throwForce = 1f;
    public GameObject bullet;
    public GameObject spawn;

    private bool reloaded;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if(ammo > 5)
        {
            ammo = 5;
        }
    }

    void Shoot()
    {
        if (ammo > 0)
        {
            if (Time.time - lastFired > 1 / fireRate)
            {
                ammo--;

                lastFired = Time.time;
                AudioManager.playShot2 = true;
                GameObject shot = Instantiate(bullet, spawn.transform.position, spawn.transform.rotation);
                Rigidbody rb = shot.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
                Destroy(shot, 1.2f);
            }
        }
    }
}
