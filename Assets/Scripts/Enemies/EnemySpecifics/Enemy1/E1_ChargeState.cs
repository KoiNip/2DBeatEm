/*************************************************************** 
*file: E1_ChargeState.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: This is the charging enemy script of the ChargeState
*script where it sets all the functions of ChargeState into 
*a data where we can use in the enemy1 component.
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_ChargeState : ChargeState
{
    private Enemy1 enemy;

    //calls the parameters from the ChargeState script and adds a new parameter in it
    public E1_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    //everytime this function is called, it will do what it is inside
    public override void DoChecks()
    {
        base.DoChecks();
    }

    //one of the overrides from the ChargeState script which when called will do whats inside
    public override void Enter()
    {
        base.Enter();
    }

    //one of the overrides from the ChargeState script which when called will exit
    public override void Exit()
    {
        base.Exit();
    }

    //one of the overrides from the ChargeState script which sets updates to logic based functions
    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }

    //one of the overrides from the ChargeState script which updates the physics aspects of whats inside
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if(performCloseRangeAction)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }
        else if(!isDetectingLedge || isDetectingWall)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }
        else if (isChargeTimeOver)
        {
            if(isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(enemy.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }
}
