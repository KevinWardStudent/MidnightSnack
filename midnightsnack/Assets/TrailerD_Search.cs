using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TrailerD_Search : K_FSMHelper
{
    /*
     * Randomly select one of the snow forts of the map, hold that position for a period of time.
     * Once down holding position, switch back to idle, which will decide a new behaviour to execute
     */

    //GameObject NPC; // A reference to the NPC this animator is attached to, refered to as NPC so as to not confuse with other scripts,etc
    GameObject[] waypoints; // Places to move the NPC towards and away, tried list, didn't understand to how properly set up
    int currentWaypoint; //Current Waypoint to which the NPC will move towards

    private Seeker seeker; //Reference to seeker script, largely unused
    public Path path; //Reference to path, a largely unused script

    [SerializeField] float timer;  //How long will the NPC remain in this state

    public float speed; //Speed at which the NPC moves
    public float attackRate; // Tracks when in the game the NPC may fire their next shot
    private float nextFire; // Tracks when in the game the NPC may fire their next shot
    [SerializeField] bool reachedPosition;

    private void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        reachedPosition = false;
        //We can instead setup a reference to the NPC using the helper when we need to call it in this class
        base.OnStateEnter(animator, stateInfo, layerIndex);
        //Pick a random value between the first value and last value of the waypoints, ie snowforts and set up a defense there

        //Search all waypoints, find closest to current pos and go to it
        for (int i = 0; i < waypoints.Length; i++)
        {
            if (Vector3.Distance(NPC.transform.position,waypoints[currentWaypoint].transform.position) < Vector3.Distance(NPC.transform.position, waypoints[currentWaypoint + 1].transform.position))
            {
                currentWaypoint++;
                if (currentWaypoint >= waypoints.Length)
                {
                    currentWaypoint = 0;
                }
            }
        }
        
            
            //currentWaypoint = Random.Range(0, waypoints.Length); // Select a waypoint to travel towards
        timer = 30f; //Set timer to a new value of 30f, the time it takes to complete a full Defense
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (waypoints.Length == 0) return; // No waypoints, no point in moving to nonexistant positions

        //Set Speed at which we move to new destination
        NPC.GetComponent<AIPath>().maxSpeed = speed;
        //Now we just need to set the target position in AI Destination Setter to the currentWaypoint's transform
        NPC.GetComponent<AIDestinationSetter>().target = waypoints[currentWaypoint].transform;
        NPC.transform.GetChild(0).GetComponent<Animator>().SetBool("Walking",true); //Set Trigger for Anim on Child to True
        //Check if got to the destination
        if (Vector3.Distance(waypoints[currentWaypoint].transform.position, NPC.transform.position) < 0.5f)
        {
            reachedPosition = true;
            NPC.transform.GetChild(0).GetComponent<Animator>().SetBool("Walking", false); //Set Trigger for Anim on Child to True
        }
         

        //After 30 seconds of no contact, return to idle to select a new behaviour
        if (timer <= 0)
        {
           
            animator.ResetTrigger("Search");
            animator.SetTrigger("NewThink");
            timer = 30f;
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
