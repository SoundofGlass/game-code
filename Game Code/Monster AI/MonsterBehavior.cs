using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterBehavior : BasicEnemyMovement
{
    
  // State Controller
    
   // public Transform target;
    
    //public BasicEnemyMovement character { get; private set; }
    

   // AI can track player through sound, sight can chase until they lose tracking and will wander

    //void Start()
    //{
        

    //  //  GameObject[] stationaryObjects = GameObject.FindGameObjectsWithTag("Stationary Objects");//AI moves around
    //    GameObject[] NPC = GameObject.FindGameObjectsWithTag("NPC"); //can be baited to attack or can also ignore
    //    GameObject[] breakableObjects = GameObject.FindGameObjectsWithTag("Breakable Objects"); //can break or ignore
    //    agent.updateRotation = false;
    //    agent.updatePosition = true;
    //    character = GetComponent<BasicEnemyMovement>();
    //}

    private void Update()
    {
       // if(target != null)
        
       //    agent.SetDestination(target.position);
       //if (DestinationReached())
       //    character.Move(agent.desiredVelocity, false, false);
       // else
       //    character.Move(Vector3.zero, false, false);
            
        
    }


    /*
     Different states the Enemy will be in.
     * Tracking
     * Roaming
     * Alert
     * Searching
     * Chasing
     * Breaking Object
     * Targeting NPC
     * Avoiding Obsticles
     */
}
