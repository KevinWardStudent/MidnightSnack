using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    [SerializeField]
    public Stat meterTest;

    private void Awake()
    {
        meterTest.Initialize();
    }

    private GameController gameController;
    public GameObject gameOver;

    private void Start()
    {
        StartCoroutine(DecreaseScore());
    }
 
    IEnumerator DecreaseScore()
    {
        while (true)
        {
            meterTest.CurrentValue -= 1f;
            yield return new WaitForSeconds(1);
        }
    }
}
