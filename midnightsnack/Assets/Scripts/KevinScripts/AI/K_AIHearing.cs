using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



/*
 * Current bugs
 * 
 * [UNSOLVED]
 * 1. When the AI hears a sound object, it draws a Ray between itself and the sound effect. Normally this should just draw the line
 * and access the necessary script for the  necessary infromation for movement. It is currently hitting the NPC's collider when it shoots
 * the raycast which is utterly annoying and causes the AI to look at itself when it should be looking at the very least the Obstalce Mask layer of
 * colliders within the scene.
 */


/// <summary>
/// Script responsible for the hearing of the player.
/// </summary>
public class K_AIHearing : MonoBehaviour
{
    [Header("AI Sound Stats")]
    [Range(0,1)]
    public float HearingThreshold; //Threshold which defines if the sound was heard by the NPC
    [Header("Misc variables")]
    NavMeshAgent nav;
    [SerializeField]
    private SphereCollider col;
    float MatSoundMultiplier = 1.0f;
    float MatSoundTotal; //Total Volume of the sound
    [Tooltip("What layerMask level should the AI be able to hear?")]
    public LayerMask layerMask;

    private Animator animBrain;

    private void Awake()
    {
        MatSoundTotal = 0f;
        animBrain = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //We check if a sound has entered the hearing collider
    //When a sound enters the hearing collider check it
    //Report back name and drive a line
    //Draw a ray between the AI and the sound effect
    //If the ray hits something and its not the tagged sound effect
    //Get Script Component and run check if present
    //Assign multiplier value to Total
    //Use Update to check if this total is high enough to cross threshold, if so AI must move to that position

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sound"))
        {
            Debug.DrawLine(transform.position, other.gameObject.transform.position,Color.blue);
            Debug.Log("I heard a " + other.transform.name);
            RaycastHit hit;
            Vector3 dir = other.transform.position - transform.position;
            if (Physics.Raycast(transform.position + transform.up,dir.normalized, out hit, col.radius, layerMask))
            {
                if (hit.transform.gameObject.tag != "sound")
                {
                    if (hit.transform.gameObject.GetComponent<K_WallMat>() != null)
                    {
                        MatSoundMultiplier = hit.transform.gameObject.GetComponent<K_WallMat>()._noiseReductionInt / 100f;
                        //Assign multiplier value to Total, compute Total as sound effect's volume multiplied by MatSoundMultiplier which inputs the reduction of the sound's volume
                        MatSoundTotal = other.gameObject.GetComponent<AudioSource>().volume * MatSoundMultiplier;
                        //Use Update to check if this total is high enough to cross threshold, if so AI must move to that position
                        Debug.Log("Indirect Volume Sound: Volume level of "+ other.transform.name+" has been reduced from "+ other.transform.gameObject.GetComponent<AudioSource>().volume+" to " + MatSoundTotal.ToString());
                        if (MatSoundTotal > HearingThreshold)
                        {
                            Debug.Log("I hear you!");
                            //Add AI Logic Here
                            //animBrain.GetComponent<K_GrandpaSitting>().closestSound = hit.transform.gameObject;
                            animBrain.SetTrigger("Search");
                        }
                    }
                    else
                    {
                        Debug.Log("The object " + hit.transform.name + " does not have the script K_WallMatt attached.");
                    }

                }
                else
                {
                    //we in fact did hit the sound effect, so its at full volume
                    //grab volume of object audio source
                    Debug.Log("Direct Volume Sound");
                    MatSoundTotal = other.gameObject.GetComponent<AudioSource>().volume;
                    if (MatSoundTotal > HearingThreshold)
                    {
                        Debug.Log("I hear you!");
                        //Add AI Logic Here
                        //animBrain.GetComponent<K_GrandpaSitting>().closestSound = hit.transform.gameObject;
                        animBrain.SetTrigger("Search");
                    }
                }
            }
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    RaycastHit hit;
    //    Vector3 dir = other.transform.position - transform.position;
    //    if (Physics.Raycast(transform.position + transform.up, dir, out hit, col.radius) && other.tag!="sound")
    //    {
    //        //MatString = hit.transform.gameObject.GetComponent<K_WallMat>()._matString;
    //        Debug.DrawLine(transform.position, other.gameObject.transform.position);
    //        //Debug.Log(other.transform.name);
    //        switch (MatString)
    //        {
    //            case "Wood":
    //                MatSoundMultiplier = 0.5f;
    //                break;
    //            default:
    //                MatSoundMultiplier = 1f;
    //                break;
    //        }
    //    }
    //    else
    //    {
    //        MatSoundMultiplier = 1f;
    //    }
    //}

    float CalculatePathLength(Vector3 targetPosition)
    {
        NavMeshPath path = new NavMeshPath();

        if (nav.enabled)
            nav.CalculatePath(targetPosition, path);

            Vector3[] allWayPoints = new Vector3[path.corners.Length+2];

            allWayPoints[0] = transform.position;
            allWayPoints[allWayPoints.Length - 1] = targetPosition;

            for (int i = 0; i < path.corners.Length; i++)
            {
                allWayPoints[i + 1] = path.corners[i];
            }

            float pathLength = 0f;

            for (int i=0; i<allWayPoints.Length-1;i++)
            {
                pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i+1]);
            }
        
        return pathLength;
    }
}
