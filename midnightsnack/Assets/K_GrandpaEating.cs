using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class K_GrandpaEating : K_FSMHelper
{
    [SerializeField] private float timer;
    GameObject waypoint;
    private Seeker seeker;
    public Path path;
    public float walkSpeed;

    private void Awake()
    {
        waypoint = GameObject.FindGameObjectWithTag("Kitchen");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //We can instead setup a reference to the NPC using the helper
        base.OnStateEnter(animator, stateInfo, layerIndex);

        timer = 10f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Set Speed at which we move to new destination
        NPC.GetComponent<AIPath>().maxSpeed = walkSpeed;
        //Now we just need to set the target position in AI Destination Setter to this currentWaypoint's transform
        NPC.GetComponent<AIDestinationSetter>().target = waypoint.transform;
        if (Vector3.Distance(waypoint.transform.position,NPC.transform.position) < 0.5f)
        {
            if (timer <= 0)
            {
                animator.ResetTrigger("Eat");
                animator.SetTrigger("FinishedActivity");
            }
            else
            {
                timer -= Time.deltaTime * 1f;
            }
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
