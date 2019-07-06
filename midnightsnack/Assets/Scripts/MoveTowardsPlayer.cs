using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public static bool attacking;

    public float speed;

    public GameObject player;
    //public GameObject enemy;
    public GameObject attack;
    private Transform target;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            attacking = true;
            attack.SetActive(true);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            transform.LookAt(target);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        attack.SetActive(false);
        attacking = false;
    }
}