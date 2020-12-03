using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script responsible for controling the AI's Vision, both in terms of real in game functionality
/// and in game rendering of the vision of the AI. To satisfy the condition the player has been seen
/// by an enemy, there needs to be three prior conditions which need to be satisfied.
/// </summary>
public class K_AIVision : MonoBehaviour
{
    [Header("Variables")]
    [Tooltip("The number of degrees, centered on the forward direction that the enemy can see through. If the enemy is outside of this field of view, the enemy will not react/lose track of the player.")]
    ///<summary>
    /// The number of degrees, centered on the forward direction that the enemy can see through.
    ///</summary>
    public float fieldOfViewAngle = 110f;
    [Range(0,360)]
    public float fieldOfViewRadius;
    [Tooltip("Control flag. Is the player in sight?")]
    ///<summary>
    /// Control flag. Is the player in sight?
    ///</summary>
    public bool playerInSight;
   

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public List<Transform> visibleTargets = new List<Transform>();

    [Tooltip("Determines how many rays we cast out per degree.")]
    ///<summary>
    /// Determines how many rays we cast out per degree.
    ///</summary>
    public float meshResolution;
    public int edgeResolveIterations;
    public float edgeDstThreshold;

    public MeshFilter viewMeshFilter;
    Mesh viewMesh;

    private Animator animBrain; //reference to brain of NPC


    private void Start()
    {
        animBrain = GetComponent<Animator>();
        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";
        viewMeshFilter.mesh = viewMesh;
        StartCoroutine("FindTargetsWithDelay",.2f);
    }

    private void LateUpdate() // Made late update so that it would render the FOV after points are decided
    {
        DrawFieldOfView();
    }

    ViewCastInfo ViewCast(float globalAngle)
    {
        Vector3 dir = DirFromAngle(globalAngle, true);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir, out hit, fieldOfViewRadius, obstacleMask))
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else
        {
            return new ViewCastInfo(false, transform.position + dir * fieldOfViewRadius, fieldOfViewRadius, globalAngle);
        }
    }


    void DrawFieldOfView()
    {
        int stepCount = Mathf.RoundToInt(fieldOfViewAngle * meshResolution); //Aka Ray count per degree within viewAngle
        float stepAngleSize = fieldOfViewAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3>(); // List of points which we will use to construct a mesh
        ViewCastInfo oldViewCast = new ViewCastInfo(); //stores previous viewcast from last frame
        for (int i=0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y - fieldOfViewAngle / 2 + stepAngleSize * i;
            //Debug.DrawLine(transform.position,transform.position+DirFromAngle(angle, true)*fieldOfViewRadius, Color.red);
            ViewCastInfo newViewCast = ViewCast(angle);

            if (i>0)
            {
                bool edgeDstThresholdExceeded = Mathf.Abs(oldViewCast.dst = newViewCast.dst) > edgeDstThreshold; 
                if (oldViewCast.hit != newViewCast.hit|| oldViewCast.hit && newViewCast.hit && edgeDstThresholdExceeded)
                {
                    EdgeInfo edge = FindEdge(oldViewCast, newViewCast);
                    if (edge.pointA != Vector3.zero)
                    {
                        viewPoints.Add(edge.pointA);
                    }
                    if (edge.pointB != Vector3.zero)
                    {
                        viewPoints.Add(edge.pointB);
                    }
                }
            }


            viewPoints.Add(newViewCast.point);
            oldViewCast = newViewCast;// store view cast for mesh clean up
        }

        int vertexCount = viewPoints.Count + 1; //Vertexs of the polygons we are going to draw, +1 is to account for origin point
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount-2) * 3];
        vertices[0] = Vector3.zero; // First vert to be origin
        //loop through verts
        for (int i = 0; i < vertexCount - 1;i++)
        {
            vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]);
            if (i < vertexCount - 2)
            {
                triangles[i * 3] = 0; // First vert of triangle
                triangles[i * 3 + 1] = i + 1; //second vert of triangle
                triangles[i * 3 + 2] = i + 2; //third of triangle
            }

            viewMesh.Clear();
            viewMesh.vertices = vertices;
            viewMesh.triangles = triangles;
            viewMesh.RecalculateNormals();

        }
    }

    EdgeInfo FindEdge(ViewCastInfo minViewCast, ViewCastInfo maxViewCast)
    {
        float minAngle = minViewCast.angle;
        float maxAngle = maxViewCast.angle;
        Vector3 minPoint = Vector3.zero;
        Vector3 maxPoint = Vector3.zero;
        //Iteration over the set number of times we will search for a line to draw so that we have a more percise mesh
        for (int i =0; i <edgeResolveIterations; i++)
        {
            float angle = (minAngle + maxAngle) / 2;
            ViewCastInfo newViewCast = ViewCast(angle);

            bool edgeDstThresholdExceeded = Mathf.Abs(minViewCast.dst = newViewCast.dst) > edgeDstThreshold;
            if (newViewCast.hit == minViewCast.hit && !edgeDstThresholdExceeded)
            {
                minAngle = angle;
                minPoint = newViewCast.point;
            }
            else
            {
                maxAngle = angle;
                maxPoint = newViewCast.point;
            }
        }

        return new EdgeInfo(minPoint, maxPoint);

    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        visibleTargets.Clear(); // clear and then re add targets in radius, allows us to update list of targets
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, fieldOfViewRadius, targetMask); // colliders which are inside of sphere center on AI, nut are within the radius of view, and only on our target mask
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            //Now We check if target is in view
            if (Vector3.Angle(transform.forward,dirToTarget) < fieldOfViewAngle/2)
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);
                //If we do not collide with anything from Raycast instantiated from our AI's position,
                //towards the target, with a dist of target, and a layerMask of obstacle mask
                //This means there are no obstacles in the way and we can see the target.
                if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask))
                {
                    //Maintain a list of targets in view
                    visibleTargets.Add(target);


                    //Check if the player IS SEEN and then set brain to acknowledge it knows the players location
                    if (target.CompareTag("Player"))
                    {
                        animBrain.SetBool("PlayerInSight", true);
                    }

                }
                else
                {
                    animBrain.SetBool("PlayerInSight",false);
                }
            }
        }
    }


    /// <summary>
    /// This method takes in an angle and then spits out the direction of that angle. Uses trigonometry to
    /// figure out the angles. Due to the way in which Unity constructs its angles, traditional trig angles
    /// do not apply. This is because 90 in trig would be 0 in unity, because, if we make a clock comparasion,
    /// traditional trig puts 90 degrees at the 12o'clock positon, rotating counter clockwise, whereas Unity puts
    /// its 0 at 12o'clock rotating clockwise. To remedy this we're going to be using a cosine in this method to
    /// get the proper rotation for our forward rotated AI.
    /// </summary>
    /// <returns> Returns a Vector 3 of the Direction of the Angle. </returns>
    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        //Boolean is used as a control for we want to use this function with an angle
        //that is not working off of unity's world coordinate, so we add to that angle the AI's own rotation to it.
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
    /// <summary>
    /// Stores info for the Raycasts drawn to show field of view.
    /// </summary>
    public struct ViewCastInfo
    {
        /// <summary>
        /// Whether the Raycast hit something or not.
        /// </summary>
        public bool hit;
        /// <summary>
        /// What is that point that the Raycast hit? A Vector3 location variable.
        /// </summary>
        public Vector3 point;
        /// <summary>
        /// Length of the ray which hit.
        /// </summary>
        public float dst;
        /// <summary>
        /// Angle at which Ray was fired.
        /// </summary>
        public float angle;

        public ViewCastInfo(bool _hit, Vector3 _point, float _dst, float _angle)
        {
            hit = _hit;
            point = _point;
            dst = _dst;
            angle = _angle;
        }
       
    }
    /// <summary>
    /// Stores info for the Edges drawn by the mesh renderer so that the visualization of the FOV is more percise.
    /// </summary>
    public struct EdgeInfo
    {
        public Vector3 pointA;
        public Vector3 pointB;

        public EdgeInfo(Vector3 _pointA, Vector3 _pointB)
        {
            pointA = _pointA;
            pointB = _pointB;
        }
    }
}
