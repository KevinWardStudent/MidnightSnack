using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_FSMHelper : StateMachineBehaviour
{
    /*
     * Inherits from StateMachineBeviour to help reduce the amount of really annoying reference variables to
     * base objects and scripts the animator components needed to know.After all pretty all of them in some
     * way need to find themselves and the player, and accessing their components to function.
     */

    public GameObject NPC; //Reference to the NPC this would be attached to
    public GameObject opponent; //Reference to the player which would be the opponent of this NPC
    public GameObject closestSound; //Reference to the sound which has been triggered by hearing collider

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        opponent = NPC.GetComponent<K_AIKnowledge>().GetPlayer(); //Call Get Player so we can access the player anytime we want
        //closestSound = NPC.GetComponent<K_AIKnowledge>();
    }
}
