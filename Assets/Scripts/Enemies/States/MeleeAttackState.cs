/*************************************************************** 
*file: MeleeAttackState.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: This is the melee attack state where the enemy
* in this state will attack the player with a melee attack
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : AttackState
{
    protected D_MeleeAttack stateData;
    protected AttackDetails attackDetails;

    //calls the parameters from the Attackstate script and adds a new parameter in it
    public MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData): base(entity, stateMachine, animBoolName, attackPosition)
    {
        this.stateData = stateData;
    }

    //everytime this function is called, it will do what it is inside
    public override void DoChecks()
    {
        base.DoChecks();
    }

    //one of the overrides from the state script which when called will do whats inside
    public override void Enter()
    {
        base.Enter();

        attackDetails.damageAmount = stateData.attackDamage;
        attackDetails.position = entity.aliveGO.transform.position;
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

    //this function will trigger an attack everytime it is called
    public override void TriggerAttack()
    {
        base.TriggerAttack();

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);

        foreach (Collider2D collider in detectedObjects)
        {
            //collider.transform.SendMessage("Damage", attackDetails);
        }
    }
}
