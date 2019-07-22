using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    //public float speed;
    public Text pickuptext;
    public Text snackText;

    private void Start()
    {
        snackText.text = "";
        pickuptext.text = "";
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            pickuptext.text = "Hold [F] to pick up item";
        }

        if (Input.GetKey(KeyCode.F) && other.gameObject.CompareTag("pickup"))
        {
            pickuptext.text = "";

            other.GetComponent<Rigidbody>().isKinematic = true;

            other.gameObject.transform.position = gameObject.transform.position;
        }
        else if (Input.GetKeyUp(KeyCode.F) && other.gameObject.CompareTag("pickup"))
        {
            pickuptext.text = "";

            other.GetComponent<Rigidbody>().isKinematic = false;
            //other.GetComponent<Rigidbody>().AddForce(transform.up * speed);
        }

        if (other.gameObject.CompareTag("Snack"))
        {
            //Debug.Log("snack eat collision");
            snackText.text = "Press [E] to eat your snack!";
        }
        if (Input.GetKeyDown(KeyCode.E) && (other.gameObject.CompareTag("Snack") || other.gameObject.CompareTag("pickup")))
        {
            other.gameObject.SetActive(false);
            FirstPersonPlayer.win = true;
            snackText.text = "";
            //gotSnack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pickuptext.text = "";
        snackText.text = "";

        if (other.gameObject.CompareTag("pickup"))
        {
            pickuptext.text = "";

            other.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}