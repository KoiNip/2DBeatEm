/*************************************************************** 
*file: MoveState.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: The move state of the enemy where the enemy
*will be able to walk around
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveState : State
{
    protected D_MoveState stateData;
    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isPlayerInMinAgroRange;
    
    //calls the parameters from state script and adds a new parameter in it
    public MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    //everytime this function is called, it will do what it is inside
    public override void DoChecks()
    {
        base.DoChecks();

        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    //one of the overrides from the state script which when called will do whats inside
    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(stateData.movementSpeed);
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
    }

    //one of the overrides from the state script which updates the physics aspects of whats inside
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
