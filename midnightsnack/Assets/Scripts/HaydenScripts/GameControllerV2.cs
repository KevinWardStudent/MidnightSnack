using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerV2 : MonoBehaviour {

    public Text winText;

    void Start ()
    {
        winText.text = "";
    }

    void Update ()
    {
        if (FirstPersonPlayer.win)
        {
            if (Timer.timer <= 30)
            {
                winText.text = "You got an S Rank!";
                FirstPersonPlayer.win = false;
            }
            else if (Timer.timer > 30 && Timer.timer <= 60)
            {
                winText.text = "You got an A Rank!";
                FirstPersonPlayer.win = false;
            }
            else if (Timer.timer > 60)
            {
                winText.text = "You got a B Rank!";
                FirstPersonPlayer.win = false;
            }
        }
    }
}
