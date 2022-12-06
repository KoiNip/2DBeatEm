/*************************************************************** 
*file: E1_LookForPlayer.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: This is the charging enemy script of the LookForPlayerState
*script where it sets all the functions of LookForPlayerState into 
*a data where we can use in the enemy1 component.
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_LookForPlayer : LookForPlayerState
{
    private Enemy1 enemy;

    //calls the parameters from the LookForPlayerState script and adds a new parameter in it
    public E1_LookForPlayer(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_LookForPlayer stateData, Enemy1 enemy): base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    //everytime this function is called, it will do what it is inside
    public override void DoChecks()
    {
        base.DoChecks();
    }

    //one of the overrides from the LookForPlayerState script which when called will do whats inside
    public override void Enter()
    {
        base.Enter();
    }

    //one of the overrides from the LookForPlayerState script which when called will exit
    public override void Exit()
    {
        base.Exit();
    }

    //one of the overrides from the LookForPlayerState script which sets updates to logic based functions
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else if(isAllTurnsTimeDone)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }

    //one of the overrides from the LookForPlayerState script which updates the physics aspects of whats inside
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
