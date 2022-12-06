/*************************************************************** 
*file: FiniteStateMachine.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: Creates the start of the finite state machine in which 
*the other scripts will be based on
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine
{
    public State currentState {get; private set; }


    public void Initialize(State startingState) //creates the beginning of the start state
    {
        currentState = startingState; //creates a state
        currentState.Enter(); //calls the state
    }
    
    //this changes the state in the finite state machien
    public void ChangeState(State newState)
    {
        currentState.Exit(); //exits the state
        currentState = newState; //creates a new state
        currentState.Enter(); //calls the new state
    }
}
