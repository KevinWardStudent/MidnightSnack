using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float movementSpeed;
    float jumpForce = 1000;
    public static bool onGround;
    public static bool gotSnack;
    public static bool win;
    public static bool lose;


    private Rigidbody rb;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //transform.rotation = Quaternion.LookRotation(movement);

        if (moveHorizontal != 0 || moveVertical != 0)      //remove this if statement to allow player to snap back to position
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);


        //unlocks the cursor when escape key is pressed
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1)) && onGround == true)
        {
            rb.AddForce(Vector3.up * jumpForce);  // * Time.deltaTime);

            //audioSource.PlayOneShot(jumpSound, .7f);
            onGround = false;
        }

        Run();
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Joystick1Button10))
        {
            movementSpeed = 11;
        }
        else
        {
            movementSpeed = 6;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Snack"))
        {
            other.gameObject.SetActive(false);
            gotSnack = true;
        }
        if (other.gameObject.CompareTag("Win") && gotSnack)
        {
            win = true;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            lose = true;
        }
    }
}
