
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    public States currentState;

    //Patrol set up
    public List<GameObject> PatrolPoints;
    public int patrolPointsNum = 0;
    public Transform[] pointsNum;
    
    

    public BasicEnemyMovement ai;
    public GameObject[] Enemy;
    public GameObject enemyToChase;
    //have a collider this it's view, change hunting state if player collides ray cast between enemy and player to make sure nothing is in the way


    //Enemy setup
    //public MonsterSightTracking Ss;
    public MonsterSightTracking Hs;
    public float detectionRange = 5.0f;
    public float roamingWaitTime = 2.0f;
    public float searchWaitTime = 7.0f;


    //Raycast set up
    public float playerTransform;

    public bool CheckIfInRange(string tag)
    {
        //Get a list of all objects with the tag.
        Enemy = GameObject.FindGameObjectsWithTag(tag);

        //See if our list is empty or not.
        if (Enemy != null)
        {
            //Run through the list of potential targets.
            foreach (GameObject t in Enemy)
            {
                //Check to see if the potential target is within detection range.
                if (Vector3.Distance(t.transform.position, transform.position) < detectionRange)
                {

                    return true;
                    // attach 2D plane to camera that increases in alpha for a time 
                    //game pauses runs this and a menu pops up
                }
            }
        }
        return false;
    }

        public Transform GetNextPatrolPoint()
    {
       // Debug.Log("Get them points.");

        //choose next point in the array as a destination
        patrolPointsNum = Random.Range(0, PatrolPoints.Count);

        //Debug.Log("RANDOM: " + patrolPointsNum);
        return PatrolPoints[patrolPointsNum].transform;
        
    }
    void Awake()
    {
        Hs = GetComponent<MonsterSightTracking>();
       // Ss = GetComponent<MonsterSightTracking>();

    }

    void Start()
    {

        PatrolPoints = GameObject.FindGameObjectsWithTag("Patrol Points").ToList();
        ai = GetComponent<BasicEnemyMovement>();
        SetState(new RoamingState(this));

        //gameObject.AddComponent<MonsterSightTracking>();
    }

    void Update()
    {
        //Debug.Log("Current State: " + currentState); 
        currentState.CheckTransitions();
        currentState.Act();

        //if player collides with enemy capsulte collider, call Enemy cast to check if player is in front of any other colliders

        //Debug.Log(currentState + "Can you set this?");
    }
    public void SetState(States state)
    {
        
        if(currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = state;
        gameObject.name = "AI agent in state" + state.GetType().Name;
        if(currentState != null)
        {
            currentState.OnStateEnter();
        }
    }
}
