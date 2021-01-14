using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class K_GrandpaChase : K_FSMHelper
{
    private Seeker seeker;
    public Path path;
    public float speed;
    public Transform spawnpoint;

    private void Awake()
    {
        spawnpoint = GameObject.FindGameObjectWithTag("Spawnpoint").transform;
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator,stateInfo,layerIndex);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC.transform.LookAt(opponent.transform.position); //Rotate AI to Player
        NPC.GetComponent<AIPath>().maxSpeed = speed; //set speed to chase speed
        NPC.GetComponent<AIDestinationSetter>().target = opponent.transform; //set AI path to player pos
        if (Vector3.Distance(NPC.transform.position, opponent.transform.position) < 2f)
        {
            opponent.transform.position = spawnpoint.position; // Player is caught by Babysitter, return Player to bedroom
        }
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
