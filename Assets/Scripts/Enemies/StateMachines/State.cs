/*************************************************************** 
*file: State.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: uses a finite statemachine to create a state
*which the other scripts will use as the basis.
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected FiniteStateMachine stateMachine; //creates a finite state machine called stateMachine from the FiniteStateMachine script
    protected Entity entity; //creates an entity named entity from the entity script
    protected float startTime; //will create a float named startTime which will set the basis time that goes through each state
    protected string animBoolName; //a string called animBoolName

    public State(Entity entity, FiniteStateMachine stateMachine, string animBoolName) //sets the parameters so the other scripts can call
    {
        this.entity = entity; //an instance variable equaled to entity
        this.stateMachine = stateMachine; //an instance variable equaled to stateMachine
        this.animBoolName = animBoolName; //an instance variable equaled to animBoolName
    }

    //one of the overrides from the state script which when called will do whats inside
    public virtual void Enter()
    {
        startTime = Time.time; //the time set into seconds which startTime will keep track of
        entity.anim.SetBool(animBoolName, true); //sets the bool of animBoolName to true
        DoChecks(); //calls DoChecks
    }

    //one of the overrides from the state script which when called will exit
    public virtual void Exit()
    {
        if(entity !=null) //checks if the entity exists
        {
            entity.anim.SetBool(animBoolName, false); //if it doesnt, the animBoolName will be set to false
        }
    }

    //one of the overrides from the state script which sets updates to logic based functions
    public virtual void LogicUpdate()
    {
        
    }

    //one of the overrides from the state script which updates the physics aspects of whats inside
    public virtual void PhysicsUpdate()
    {
        DoChecks(); //calls DoChecks
    }

    //everytime this function is called, it will do what it is inside
    public virtual void DoChecks()
    {

    }
}
