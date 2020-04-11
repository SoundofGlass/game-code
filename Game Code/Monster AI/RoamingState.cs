using UnityEngine;

public class RoamingState : States
{
    Transform destination;


    public RoamingState(StateController stateController): base(stateController) { }

    public override void CheckTransitions()
    {
       //checks is there is a player to chase

        if (statecontroller.Hs.playerSeen)
        {
            statecontroller.SetState(new HuntingState(statecontroller));
            statecontroller.ai.SetTarget(statecontroller.Hs.player.transform);
        }

    }

    public override void Act()
    {
        if(destination == null)
        {
           // Debug.Log("Oops no destination ");
        }
       //sets state to roaming and wanders randomly between points
       if(destination == null || statecontroller.ai.DestinationReached())
        {
           // Debug.Log("I have reached it!" + statecontroller.GetNextPatrolPoint());
            destination = statecontroller.GetNextPatrolPoint();
            statecontroller.ai.SetTarget(destination);
        }
    }
    public override void OnStateEnter()
    {
        
        destination = statecontroller.GetNextPatrolPoint();
        //Debug.Log(destination);
      //  if (statecontroller.ai.agent)
      //  {
           // Debug.Log("I also see this script " + statecontroller.GetNextPatrolPoint());
            statecontroller.ai.Agent.speed = 1f;
        //  }
        statecontroller.ai.SetTarget(destination);

        
    }
}


