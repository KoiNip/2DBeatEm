/*************************************************************** 
*file: PlayerDetectedState.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: To have the enemy have a player detect state when
*the player gets close to the enemy
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : State //inherits state
{
    protected D_PlayerDetected stateData;

    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;
    protected bool peformLongRangeAction;
    protected bool performCloseRangeAction; 

    //calls the parameters from the state script
    public PlayerDetectedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData) : base(etity, stateMachine, animBoolName) 
    {
        this.stateData = stateData; 
    }

    //everytime this function is called, it will do what it is inside
    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange(); //checks the player it is the min range
        isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange(); //checks the player it is in max range

        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction(); //checks if the player is in close range
    }

    //one of the overrides from the state script which when called will do whats inside
    public override void Enter()
    {
        base.Enter();

        peformLongRangeAction = false; //sets the long range action to false since this will come later on
        entity.SetVelocity(0f);  //sets the set velocity to 0
    }

    //one of the overrides from the state script which when called will exit
    public override void Exit()
    {
        base.Exit();
    }

    //one of the overrides from the state script which sets updates to logic based functions
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //this function makes sure that if the time in seconds is greateer than the start time it will set the peformLongRange action to true
        if (Time.time >= startTime + stateData.longRangeActionTime)
        {
            peformLongRangeAction = true;
        }
    }

    //one of the overrides from the state script which updates the physics aspects of whats inside
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();     
    }
}
