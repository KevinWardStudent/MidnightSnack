using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecker : MonoBehaviour
{

    public GameObject player;
    public GameObject AI;
    public GameObject waypoint1;

    private void Update()
    {
        transform.position = AI.transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Patrol.agent.SetDestination(player.transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Patrol.agent.SetDestination(Patrol.waypoint1.transform.position);
            Patrol.agent.SetDestination(waypoint1.transform.position);
        }
    }
}
