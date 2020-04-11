
using UnityEngine;

public class MonsterSightTracking : MonoBehaviour
{
    /* 
     * Summary
     * 
     * Eyes of the Beasts
     * Using Sphere colliders to create cones that ray casts when crossed with players rigidbody
     * Will eventually add a way to track the state of the player for noise
     * Wind will eventually affect the sphere collider for scent
     * 
     * End Summary
     */



    //Variables setting up the eyes of the beasts
    public float fieldOfViewAngle = 130f; //width of monster view angle
    public bool playerSeen;// true is player is unobstructed and in collider, otherwise false
    public bool playerHeard; //may not use atm
    private SphereCollider sightCone; // Enemy's eyes
    public GameObject player; //Player
    private Vector3 previousSighting; // Stores where the player was last seen when sight is lost
    public Transform previousSightTransform;


    private UnityEngine.AI.NavMeshAgent Agent;


    public HuntingState HS;
    //public SearchState Ss;

    private void Start()
    {
        sightCone = GetComponentInChildren<SphereCollider>();
        Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {

            playerSeen = false;
            playerHeard = false;


            Vector3 direction = player.transform.position - transform.position;

            //get the angle of then player from the guard forward facin pos
            float angle = Vector3.Angle(direction, transform.forward);

            if(angle < fieldOfViewAngle * 0.75f)
            {
                
                RaycastHit hit;

                if(Physics.Raycast(transform.position, direction.normalized, out hit, sightCone.radius))
                {
                    Debug.DrawRay(transform.position, player.transform.position, Color.yellow);
                    //make sure whe hit the player
                    if(hit.collider.gameObject == player)
                    {
                        Debug.DrawRay(transform.position, player.transform.position, Color.white);
                        playerSeen = true;
                        //Debug.Log(playerSeen + " Detected!");
                        
                    }
                }
            }

            //this is where I can write the script for the player being heard once I have a player statecontroller


        }
    }

    private void OnTriggerExit(Collider other)//when the player exits the collider
    {
        if (other.gameObject == player)
        {
            playerSeen = false;

            //players last transform when sight is lost
            previousSightTransform = player.transform;
        }
    }

    //calculates the path distance between enemy and target
    float CalculatePathLength(Vector3 targetPosition)
    {
        //creates a new nav mesh path
        UnityEngine.AI.NavMeshPath path = new UnityEngine.AI.NavMeshPath();

        //makes sure the navigation is there, and get path from agent
        if (Agent.enabled)
        {
            Agent.CalculatePath(targetPosition, path);
        }

        Vector3[] addedPatrolPoints = new Vector3[path.corners.Length + 2];

        //set the first point to the enemy pos, and last point to target pos
        addedPatrolPoints[0] = transform.position;
        addedPatrolPoints[addedPatrolPoints.Length - 1] = targetPosition;
        

        //the loops sets all the inbetween values of the waypoints. So the first value will be enemy pos, second 
        //value will be first patrol point or corner, 
        for(int i = 0; i< path.corners.Length; i++)
        {
            addedPatrolPoints[i + 1] = path.corners[1];
        }
        //tracks length
        float pathLength = 0f;

        //add calues of the lengths between patrols points
        for(int i =0; i < addedPatrolPoints.Length-1; i++)
        {
            pathLength += Vector3.Distance(addedPatrolPoints[i], addedPatrolPoints[i + 1]);
        }

        return pathLength;
    }
}
