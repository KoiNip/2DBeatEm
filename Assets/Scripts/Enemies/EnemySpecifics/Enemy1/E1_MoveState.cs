/*************************************************************** 
*file: E1_MoveState.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: This is the charging enemy script of the MoveState
*script where it sets all the functions of MoveState into a data 
*where we can use in the enemy1 component.
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class E1_MoveState : MoveState
{
    private Enemy1 enemy;

    //calls the parameters from the MoveState script and adds a new parameter in it
    public E1_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    //one of the overrides from the MoveState script which when called will do whats inside
    public override void Enter()
    {
        base.Enter();
    }

    //one of the overrides from the MoveState script which when called will exit
    public override void Exit()
    {
        base.Exit();
    }

    //one of the overrides from the MoveState script which sets updates to logic based functions
    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }

    //one of the overrides from the MoveState script which updates the physics aspects of whats inside
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else if(isDetectingWall || !isDetectingLedge)
        {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
