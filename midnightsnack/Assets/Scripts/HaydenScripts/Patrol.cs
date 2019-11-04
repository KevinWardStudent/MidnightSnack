using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Patrol : MonoBehaviour {

    //public UnityEngine.AI.NavMeshAgent agent;

    //public Vector3 waypoint1;
    //public GameObject waypoint1;
    public GameObject waypoint2;
    //public GameObject waypoint3;
    public GameObject player;
    public GameObject alert;
    public GameObject attack;

    public static NavMeshAgent agent;

    AudioSource audioSource;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;

    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();

        audioSource = GetComponent<AudioSource>();
    }

    /*void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            patrol();
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("nerf"))
        {
            audioSource.PlayOneShot(sound3, 1.5f);
            attack.SetActive(true);
            agent.speed = 5;
            agent.SetDestination(player.transform.position);
            StartCoroutine(nerfpause());
        }
        if (other.gameObject.CompareTag("Player") && FirstPersonPlayer.exposed)
        {
            audioSource.PlayOneShot(sound1, .7f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && FirstPersonPlayer.exposed)
        {
            attack.SetActive(true);
            agent.speed = 7;
            agent.SetDestination(player.transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(pause());
            //agent.SetDestination(waypoint1.transform.position);
        }
    }

    ///*void patrol()
    //{
    //    agent.SetDestination(waypoint1.transform.position);

    //    StartCoroutine(pause());
    //}*/

    IEnumerator pause()
    {
        attack.SetActive(false);
        agent.SetDestination(gameObject.transform.position);
        alert.SetActive(true);
        //audioSource.PlayOneShot(sound2, 1.1f);
        yield return new WaitForSeconds(0.75f);
        alert.SetActive(false);
        agent.speed = 3.5f;
        agent.SetDestination(waypoint2.transform.position);
    }

    IEnumerator nerfpause()
    {
        //alert.SetActive(true);
        yield return new WaitForSeconds(3f);
        attack.SetActive(false);
        alert.SetActive(true);
        audioSource.PlayOneShot(sound2, 1.5f);
        yield return new WaitForSeconds(0.75f);
        alert.SetActive(false);
        agent.speed = 3.5f;
        agent.SetDestination(waypoint2.transform.position);
    }
}
