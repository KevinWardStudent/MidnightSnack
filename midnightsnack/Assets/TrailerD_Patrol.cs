using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TrailerD_Patrol : K_FSMHelper
{
    GameObject[] waypoints; // Places to move the NPC towards and away, tried list, didn't understand to how properly set up
    int currentWaypoint; //Current Waypoint to which the NPC will move towards

    private Seeker seeker;
    public Path path;
    [SerializeField] float timer;

    public float speed;

    private void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // No longer need because of helper class//NPC = animator.gameObject; //Grab reference to the GameObject that this animator is attached 
        //currentWaypoint = 0; //Sets currentWaypoint to 0, ie the first position but we want the AI to randomly decide a pattern


        //We can instead setup a reference to the NPC using the helper
        base.OnStateEnter(animator, stateInfo, layerIndex);
        //Pick a random value between the first value and last value of the waypoints, ie snowforts and begin the patrol there
        currentWaypoint = Random.Range(0, waypoints.Length); // Select a waypoint to travel towards
        timer = 30f; //Set timer to a new value of 30f, the time it takes to complete a full patrol
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (waypoints.Length == 0) return; // No waypoints, no point in moving to nonexistant positions
        // Check when the npc is close enough to a snowfort, where a waypoint is placed, and do.... 
        if (Vector3.Distance(waypoints[currentWaypoint].transform.position, NPC.transform.position) < 0.5f)
        {
            //Have the waypoint index value be increased, as we have completed our patrol to this location
            //Cycle to the next waypoint and be sure that if we go over the total amount of waypoints, we
            //reset our waypoints back down to zero, ie the first position so that we can patrol to that target
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }

        //Set Speed at which we move to new destination
        NPC.GetComponent<AIPath>().maxSpeed = speed;
        //Now we just need to set the target position in AI Destination Setter to this currentWaypoint's transform
        NPC.GetComponent<AIDestinationSetter>().target = waypoints[currentWaypoint].transform;
        NPC.transform.GetChild(0).GetComponent<Animator>().SetBool("Walking", true); //Set Trigger for Anim on Child to True
        //Change Behaviour back to idle if 30 seconds pass without contact with the player, reset Patrol
        if (timer <= 0)
        {
            Debug.Log("No more patrol");
            NPC.transform.GetChild(0).GetComponent<Animator>().SetBool("Walking", false); //Set Trigger for Anim on Child to True
            animator.ResetTrigger("Patrol");
            animator.SetTrigger("NewThink");
        }
        else
        {
            timer -= Time.deltaTime * 1f;
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
