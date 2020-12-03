using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_GrandpaThinking : K_FSMHelper
{
    /*
     * Responsible for resetting all transition parameters and for giving a start behavoiur to all
     * NPCs which are spawn as successive waves of Enemies come towards the player. Begins with a random number
     * generator and then picks one of three main behaviours to execute, Defense, Patrol, Assault. There exist
     * also two other sub behaviours, Retreat and Contact which then move between the three parent states.
     */
    int BehaviourIndex; // 1=Patrol,2=Activity

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Reset all transitions, except DistanceFromPlayer and Thinking(Obviously)
        animator.ResetTrigger("Patrol");
        animator.ResetTrigger("Eat");
        animator.ResetTrigger("Sit");
        animator.ResetTrigger("Activity");
        animator.ResetTrigger("Sleep");
        animator.ResetTrigger("WatchTV");
        animator.ResetTrigger("FinishedActivity");
        animator.SetBool("PlayerInSight", false);
        animator.ResetTrigger("Search");
        BehaviourIndex = Random.Range(1,3);
        if (BehaviourIndex == 1)
        {
            Debug.Log("Patrol");
            animator.SetTrigger("Patrol");
        }
        else
        {
            Debug.Log("Activity");
            animator.SetTrigger("Activity");
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

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
