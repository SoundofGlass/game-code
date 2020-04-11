using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class BasicEnemyMovement : MonoBehaviour
{
    
    /*
     * Summary
     * 
     * Basic movemeny of the Enemy AI using solely NavMeshAgents
     * 
     * End Summary

     */

    

    public float speed;
    public Transform target;


    public NavMeshAgent Agent { get; private set; }


    public void Start()
    {
        Agent = GetComponentInChildren<NavMeshAgent>();
       // Debug.Log(Agent + " Is seen");
        Agent.updatePosition = true;


       

    }
    void Update()
    {


        //finds target to look at
        // target = Quaternion.LookRotation(enemy.transform.position - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, speed * Time.deltaTime);

        // Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime); 

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
        agent.speed = 3;

    }
    public bool DestinationReached()
    {
        return Agent.remainingDistance < Agent.stoppingDistance;
    }
    public void Move(Vector3 move, float velocity)
    {
         move +=  Vector3.forward * Time.deltaTime * velocity;
        //  move = transform.position += -Vector3.forward * Time.deltaTime * velocity;

        transform.position = move;

        //moves another the x and y vectors, 



    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
