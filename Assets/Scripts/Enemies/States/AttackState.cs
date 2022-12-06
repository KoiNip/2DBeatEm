/*************************************************************** 
*file: AttackState.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: To create an attack state for the enemy. so when the
*enemy gets close to the player, it will do an attack
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    protected Transform attackPosition;

    protected bool isAnimationFinished;
    protected bool isPlayerInMinAgroRange;
    
    //calls the parameters from the State script and adds a new parameter in it
    public AttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition) : base(entity, stateMachine, animBoolName)
    {
        this.attackPosition = attackPosition;
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

        entity.atsm.attackState = this;
        isAnimationFinished = false;
        entity.SetVelocity(0f);
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

    //it will trigger an attack from the enemy once called
    public virtual void TriggerAttack()
    {

    }

    //it will be called once the enemy finished the attack animation
    public virtual void FinishAttack()
    {
        isAnimationFinished = true;
    }
}