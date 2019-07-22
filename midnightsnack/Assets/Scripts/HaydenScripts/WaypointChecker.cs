using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointChecker : MonoBehaviour {

    public GameObject waypoint1;
    public GameObject waypoint2;
    public GameObject waypoint3;
    //public GameObject player;
    //public GameObject alert;
    //public GameObject attack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("waypoint1"))
        {
            Patrol.agent.SetDestination(waypoint2.transform.position);
        }
        else if (other.gameObject.CompareTag("waypoint2"))
        {
            Patrol.agent.SetDestination(waypoint3.transform.position);
        }
        else if (other.gameObject.CompareTag("waypoint3"))
        {
            Patrol.agent.SetDestination(waypoint1.transform.position);
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        attack.SetActive(true);
    //        Patrol.agent.speed = 7;
    //        Patrol.agent.SetDestination(player.transform.position);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        StartCoroutine(pause());
    //        //agent.SetDestination(waypoint1.transform.position);
    //    }
    //}

    /*void patrol()
    {
        agent.SetDestination(waypoint1.transform.position);

        StartCoroutine(pause());
    }*/

    //IEnumerator pause()
    //{
    //    attack.SetActive(false);
    //    Patrol.agent.SetDestination(gameObject.transform.position);
    //    alert.SetActive(true);
    //    yield return new WaitForSeconds(0.75f);
    //    alert.SetActive(false);
    //    Patrol.agent.speed = 3.5f;
    //    Patrol.agent.SetDestination(waypoint2.transform.position);
    //}
}
