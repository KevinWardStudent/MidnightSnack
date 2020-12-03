using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_GrandpaActivity : K_FSMHelper
{

    int BehaviourIndex; //1=Eat,2=Sitting,3=Sleep,4=WatchTV
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        BehaviourIndex = Random.Range(1,4);
        animator.ResetTrigger("FinishedActivity");
        animator.ResetTrigger("Eat");
        animator.ResetTrigger("Sit");
        animator.ResetTrigger("Sleep");
        animator.ResetTrigger("WatchTV");
        if (BehaviourIndex == 1)
        {
            animator.ResetTrigger("Activity");
            animator.SetTrigger("Eat");
        }
        else if (BehaviourIndex == 2)
        {
            animator.ResetTrigger("Activity");
            animator.SetTrigger("Sit");
        }
        else if (BehaviourIndex == 3)
        {
            animator.ResetTrigger("Activity");
            animator.SetTrigger("Sleep");
        }
        else
        {
            animator.ResetTrigger("Activity");
            animator.SetTrigger("WatchTV");
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
