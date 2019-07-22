using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject enemy;
    public GameObject alert;
    public Transform target;

    private void Update()
    {
        transform.position = enemy.transform.position;

        if (MoveTowardsPlayer.attacking)
        {
            enemy.transform.LookAt(target);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !MoveTowardsPlayer.attacking)
        {
            alert.SetActive(true);
            enemy.transform.LookAt(target);
        }
        else if (MoveTowardsPlayer.attacking)
        {
            alert.SetActive(false);
            //enemy.transform.LookAt(target);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        alert.SetActive(false);
    }
}
