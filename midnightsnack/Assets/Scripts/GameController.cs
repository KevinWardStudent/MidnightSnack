using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject winFX;
    public GameObject player;

    public Text snackText;
    public Text winText;
    public Text loseText;
    public Text startText;

    void Start ()
    {
        snackText.text = "";
        winText.text = "";
        loseText.text = "";
        startText.text = "Time to get a snack! Avoid the babysitter!";
        StartCoroutine(wait());
    }

    void Update ()
    {
        if (PlayerController.gotSnack)
        {
            snackText.text = "You got a snack! Now get back to bed!";
            StartCoroutine(snack());
        }
        if (PlayerController.win)
        {
            winText.text = "You made it back! You win!";
            winFX.SetActive(true);
        }
        if (PlayerController.lose)
        {
            loseText.text = "You have been caught! You are in big trouble!";
            player.SetActive(false);
        }
    }

    IEnumerator snack()
    {
        yield return new WaitForSeconds(2);
        snackText.text = "";
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        startText.text = "";
    }
}
