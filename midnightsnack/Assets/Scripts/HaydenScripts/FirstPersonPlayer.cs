using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonPlayer : MonoBehaviour
{
    public float speed;
    float jumpForce = 650;
    public static bool onGround;
    public static bool win;
    public static bool exposed;
    private bool nerfgunpickedup;
    private bool toggle;

    public GameObject nerfg;
    public GameObject nerfpickupFX;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        nerfg.SetActive(false);
    }

    void Update ()
    {
        Move();
        Jump();
        ToggleNerfGun();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 PlayerMovement = new Vector3(h, 0f, v) * speed * Time.deltaTime;
        transform.Translate(PlayerMovement, Space.Self);
    }

    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1)) && onGround == true)
        {
            rb.AddForce(Vector3.up * jumpForce);  // * Time.deltaTime);

            //audioSource.PlayOneShot(jumpSound, .7f);
            onGround = false;
        }
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
            Instantiate(nerfpickupFX, other.transform.position, other.transform.rotation);
            other.gameObject.SetActive(false);
            nerfg.SetActive(true);
            nerfgunpickedup = true;
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
