using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class States 
{
    protected StateController statecontroller;

    // you want the state controller to determine what the AI is doing, not the AI itself
    
    public abstract void Act();//if state change is needed

    public abstract void CheckTransitions();// check if state change is needed

    public virtual void OnStateEnter() { }// for feedback on the agent changing state

    public virtual void OnStateExit() { }

    //Constructor
    public States(StateController stateController) => statecontroller = stateController;
}
