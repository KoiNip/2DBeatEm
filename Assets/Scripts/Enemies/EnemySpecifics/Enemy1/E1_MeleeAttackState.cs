/*************************************************************** 
*file: E1_MeleeAttackState.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: This is the charging enemy script of the MeleeAttackState
*script where it sets all the functions of MeleeAttackState into 
*a data where we can use in the enemy1 component.
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MeleeAttackState : MeleeAttackState
{
    private Enemy1 enemy;

    //calls the parameters from the MeleeAttackState script and adds a new parameter in it
    public E1_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData, Enemy1 enemy): base(entity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.enemy = enemy;
    }

    //everytime this function is called, it will do what it is inside
    public override void DoChecks()
    {
        base.DoChecks();
    }

    //one of the overrides from the MeleeAttackState script which when called will do whats inside
    public override void Enter()
    {
        base.Enter();
    }

    //one of the overrides from the MeleeAttackState script which when called will exit
    public override void Exit()
    {
        base.Exit();
    }

    //one of the overrides from the MeleeAttackState script which when called will finish the attack animation
    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    //one of the overrides from the MeleeAttackState script which sets updates to logic based functions
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isAnimationFinished)
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

    //one of the overrides from the MeleeAttackState script which updates the physics aspects of whats inside
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    //one of the overrides from the MeleeAttackState script which when called will trigger the attack
    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
