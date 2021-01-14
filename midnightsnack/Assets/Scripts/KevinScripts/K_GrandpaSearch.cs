using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class K_GrandpaSearch : K_FSMHelper
{
    private Seeker seeker;
    public Path path;
    public float speed;
    [SerializeField]
    private GameObject sound;
    private GameObject lastKnownSound;
    [SerializeField] private float timer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //We can instead setup a reference to the NPC using the helper
        base.OnStateEnter(animator, stateInfo, layerIndex);
        sound = getClosestSound(NPC);
        timer = 10f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (sound == null)
        {
            sound = getClosestSound(NPC);
            //timer = 3f;
            return;
        }
        NPC.GetComponent<AIPath>().maxSpeed = speed; //Set speed of AI to search LD Note: 'Prob slow, maybe 2'
        NPC.GetComponent<AIDestinationSetter>().target = sound.transform; // Set target positon to the transform of sound
        if (timer <= 0)
        {
            animator.ResetTrigger("Search");
            animator.SetTrigger("Patrol");
        }
        else
        {
            timer -= 1f * Time.deltaTime;
        }
    }

    public GameObject getClosestSound(GameObject NPC)
    {
        GameObject[] sounds = GameObject.FindGameObjectsWithTag("sound");
        float closestDist = Mathf.Infinity;
        GameObject closestSound = null;
        //Check each sound found in the scene
        foreach (GameObject newSound in sounds)
        {
            float currentDist;
            currentDist = Vector3.Distance(NPC.transform.position, newSound.transform.position);
            if (currentDist < closestDist)
            {
                closestDist = currentDist;
                closestSound = newSound;
            }
        }
        return closestSound;
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
