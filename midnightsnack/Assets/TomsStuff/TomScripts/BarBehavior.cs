using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarBehavior : MonoBehaviour
{
    private PlayerTest testPlayer;

    private void Start()
    {
        GameObject testPlayerObject = GameObject.FindWithTag("Player");
        if (testPlayerObject != null)
        {
            testPlayer = testPlayerObject.GetComponent<PlayerTest>();
        }
    }

    /*
    private void FixedUpdate()
    {
        if (testPlayer.meterTest.CurrentValue == 0)
        {
            testPlayer.gameOver.SetActive(true);
            Destroy(gameObject);
        }
    }
    */

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            testPlayer.meterTest.CurrentValue += 10;
            gameObject.SetActive(false);
        }

    }
}
