/*************************************************************** 
*file: ChargeState.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: To create a charge state for the enemy so when it sees
*the player, the enemy will charge at the player
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : State
{
    protected D_ChargeState stateData;

    protected bool isPlayerInMinAgroRange;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;
    protected bool isChargeTimeOver;
    protected bool performCloseRangeAction;

    //calls the parameters from the State script and adds a new parameter in it
    public ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    //everytime this function is called, it will do what it is inside
    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();

        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }

    //one of the overrides from the state script which when called will do whats inside
    public override void Enter()
    {
        base.Enter();

        isChargeTimeOver = false;
        entity.SetVelocity(stateData.chargeSpeed);
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

        if(Time.time >= startTime + stateData.chargeTime)
        {
            isChargeTimeOver = true;
        }
    }

    //one of the overrides from the state script which updates the physics aspects of whats inside
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

