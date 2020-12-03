using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_AIKnowledge : MonoBehaviour
{
    /*  
     *  Gets and stores the player game object. This will be inherited by all animator states.
     *  Also might handle sound effects at some point down the road.
     */
    public GameObject player;
    Animator anim;
    public GameObject sound;
    //Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Find ref to player
        anim = GetComponent<Animator>();
    }

    public GameObject GetPlayer()
    {
        return player;
    }
    public GameObject GetSound()
    {
        return sound;
    }
    public void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Find ref to player
        //Consistant check if the distance from player to NPC, so that when at a cetain float is triggered,
        //we decide on a behaviour, we can use Vector3.Distance to do this calculation
        anim.SetFloat("DistanceFromPlayer", Vector3.Distance(transform.position, player.transform.position));
    }

    public GameObject getClosestSound()
    {
        GameObject[] sounds = GameObject.FindGameObjectsWithTag("sound");
        float closestDist = Mathf.Infinity;
        GameObject closestSound = null;
        //Check each sound found in the scene
        foreach (GameObject newSound in sounds)
        {
            float currentDist;
            currentDist = Vector3.Distance(transform.position, newSound.transform.position);
            if (currentDist < closestDist)
            {
                closestDist = currentDist;
                closestSound = newSound;
            }
        }
        return closestSound;
    }
}
