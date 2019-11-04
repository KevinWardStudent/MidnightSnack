using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFPController : MonoBehaviour
{

    public float speed = 0f;
    public bool onGround;
    public float jumpForce;
    public static float dashCount;

    public static bool exposed;
    private bool nerfgunpickedup;
    private bool toggle;

    public GameObject nerfg;
    public GameObject nerfpickupFX;
    public GameObject dPanel1;
    public GameObject dPanel2;

    private Rigidbody rb;

    void Start()
    {
        dashCount = 2;
        //turns off cursor and keeps it inside game window
        Cursor.lockState = CursorLockMode.Locked;

        nerfg.SetActive(false);

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ToggleNerfGun();
        
        float translation = Input.GetAxis("Vertical") * speed;
        float strafe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);

        //unlocks the cursor when escape key is pressed
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown("space") && onGround == true)
        {
            rb.AddForce(Vector3.up * jumpForce);
            //audioSource.PlayOneShot(jumpSound, .7f);
            onGround = false;
        }

        if (NerfGun.ammo > 5)
        {
            NerfGun.ammo = 5;
        }

        if (dashCount > 0)
        {
            Run();
        }
        if (dashCount > 2)
        {
            dashCount = 2;
        }
        if (dashCount == 0)
        {
            dPanel1.SetActive(false);
            dPanel2.SetActive(false);
        }
        if (dashCount == 1)
        {
            dPanel1.SetActive(true);
            dPanel2.SetActive(false);
        }
        if (dashCount == 2)
        {
            dPanel1.SetActive(true);
            dPanel2.SetActive(true);
        }
    }

    void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(dash());
            //speed = 100;
        }
        else
        {
            //speed = 5;
        }
    }

    IEnumerator dash()
    {
        AudioManager.playDash = true;
        dashCount--;
        speed = 18;
        yield return new WaitForSeconds(0.4f);
        speed = 5;
    }


    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }


    void ToggleNerfGun()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && nerfgunpickedup == true)
        {
            nerfg.SetActive(false);
            nerfgunpickedup = false;
            toggle = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && toggle)
        {
            nerfg.SetActive(true);
            nerfgunpickedup = true;
            toggle = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("nerfgun"))
        {
            //GameControllerV2.displayAmmo = true;
            NerfGun.ammo += 2;
            Instantiate(nerfpickupFX, other.transform.position, other.transform.rotation);
            other.gameObject.SetActive(false);
            nerfg.SetActive(true);
            nerfgunpickedup = true;
        }
        if (other.gameObject.CompareTag("dash"))
        {
            dashCount++;

            other.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("exposed"))
        {
            exposed = true;
        }
        if (other.gameObject.CompareTag("hidden"))
        {
            exposed = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("exposed"))
        {
            exposed = false;
        }
    }
}