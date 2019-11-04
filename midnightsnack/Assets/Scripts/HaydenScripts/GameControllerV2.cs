using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerV2 : MonoBehaviour
{
    public static bool win;
    public static bool displayAmmo;

    public Text winText;
    public Text hiddenText;
    public Text ammoText;

    void Start ()
    {
        winText.text = "";
        hiddenText.text = "";
        ammoText.text = "";
        NerfGun.ammo = 0;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
        if (FirstPersonPlayer.win)
        {
            if (Timer.timer <= 30)
            {
                winText.text = "You got an S Rank!";
                win = false;
            }
            else if (Timer.timer > 30 && Timer.timer <= 60)
            {
                winText.text = "You got an A Rank!";
                win = false;
            }
            else if (Timer.timer > 60)
            {
                winText.text = "You got a B Rank!";
                win = false;
            }
        }

        if(NewFPController.exposed == true)
        {
            hiddenText.text = "Exposed";
        }
        if (NewFPController.exposed == false)
        {
            hiddenText.text = "Hidden";
        }


        //if (displayAmmo)
        //{
            ammoText.text = "" + NerfGun.ammo;
        //}
    }
}
