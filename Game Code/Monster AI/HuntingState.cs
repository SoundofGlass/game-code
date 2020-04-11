
using UnityEngine;

public class HuntingState : States
{

    public float startTime = 0f;
    public float endTime = 2f;
    //Vector3 destination;
    
    public HuntingState(StateController stateController) : base(stateController) { }


    public override void CheckTransitions()
    {
       if(!statecontroller.Hs.playerSeen)
        {
            //transitions to search state
            statecontroller.SetState(new SearchState(statecontroller));
        }

    }

    public override void OnStateEnter()
    {
        startTime = 0;



        //after a certain distance is reached towards the player, run game over script.
    }
    public override void Act()
    {
        //act is what I want the enemy to do every update
        //Debug.Log("I am now chasing you!");
        if (startTime <= endTime)
        {
            startTime += Time.deltaTime;
            
            statecontroller.ai.Agent.isStopped = true;
        }
        else
        {
            statecontroller.ai.Agent.isStopped = false;
            statecontroller.ai.Agent.speed = 2f;
            statecontroller.ai.Agent.SetDestination(statecontroller.Hs.player.transform.position);
        }
            


    }
    
}
