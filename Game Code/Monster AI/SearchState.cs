using UnityEngine;

public class SearchState : States
{

    float startTimeToLook = 0f;
    float endTimeToLook = 7f;

    
    public SearchState(StateController stateController) : base(stateController) { }


    //goes to last known transform position of the player when it loses sight and tries to regain it's target
    //for a few seconds. If still not regained, switch to roaming state.
    public override void CheckTransitions()
    {


        if (statecontroller.Hs.playerSeen)
        {
            statecontroller.SetState(new HuntingState(statecontroller));
            statecontroller.ai.SetTarget(statecontroller.Hs.player.transform);
        }

    }
    public override void OnStateEnter()
    {
        startTimeToLook = 0f;
        //Debug.Log("Searching is for losers.");
       
       //walks to last stored position  and turned itself around.
       //check last know pos of player from monster sight tracking
    }

    public override void Act()
    {
        startTimeToLook += Time.deltaTime;
        if (startTimeToLook <= endTimeToLook)
        {
            //Debug.Log(" player seen " + statecontroller.Hs.playerSeen);
            if (!statecontroller.Hs.playerSeen)
            {
                //Debug.Log("Players Last location" + statecontroller.Hs.previousSightTransform.position);
                //rotate agent
                statecontroller.ai.Agent.SetDestination(statecontroller.Hs.previousSightTransform.position);
                if(Vector3.Distance(statecontroller.ai.Agent.transform.position, statecontroller.Hs.previousSightTransform.position ) <= .1f)
                {
                    statecontroller.ai.Agent.isStopped = true;
                }
                
            }


        }  else
            {
                //go back to roaming?
                statecontroller.ai.Agent.isStopped = false;
                statecontroller.SetState(new RoamingState(statecontroller));              
            }

    }
}
