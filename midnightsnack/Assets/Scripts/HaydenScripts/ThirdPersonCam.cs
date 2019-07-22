using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public float rotationSpeed;
    //public Transform target;
    public GameObject player;
    public GameObject cam;


    float mouseX;
    //float mouseY;


	void Start ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	void LateUpdate ()
    {
        CamController();
	}

    void CamController()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        //mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        //transform.LookAt(target);

        player.transform.rotation = cam.transform.rotation;


        //target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        //player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
