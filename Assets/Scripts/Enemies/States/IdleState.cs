/*************************************************************** 
*file: IdleState.cs
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: This will create the idle state of the enemy when it
*sees a wall or ledge or when it player is out of range of the
* enemy.
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IdleState : State
{
    protected D_IdleState stateData;
    protected bool flipAfterIdle;
    protected bool isIdleTimeOver;
    protected bool isPlayerInMinAgroRange;
    protected float idleTime;

    //calls the parameters from the State script and adds a new parameter in it
    public IdleState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData) : base(etity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    //everytime this function is called, it will do what it is inside
    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    //one of the overrides from the state script which when called will do whats inside
    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(0f);
        isIdleTimeOver = false;        
        SetRandomIdleTime();
    }

    //one of the overrides from the state script which when called will exit
    public override void Exit()
    {
        base.Exit();
        if (flipAfterIdle)
        {
            entity.Flip();
        }
    }

    //one of the overrides from the state script which sets updates to logic based functions
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Time.time >= startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }

    //one of the overrides from the state script which updates the physics aspects of whats inside
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();        
    }

    //This function will make the enemy flip once it becomes idle
    public void SetFlipAfterIdle(bool flip)
    {
        flipAfterIdle = flip;
    }

    //this function will set a random idle time of how long the enemey will stay idle
    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}