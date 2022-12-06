/*************************************************************** 
*file: DeadState.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: To create a dead state for the enemy so once the
*the enemy reaches 0 hp, it will be dead
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    protected D_DeadState stateData;

    //calls the parameters from the State script and adds a new parameter in it
    public DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData): base(entity, stateMachine, animBoolName)
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

        GameObject.Instantiate(stateData.deathBloodParticle, entity.aliveGO.transform.position, stateData.deathBloodParticle.transform.rotation);
        GameObject.Instantiate(stateData.deathChunkParticle, entity.aliveGO.transform.position, stateData.deathChunkParticle.transform.rotation);

        entity.gameObject.SetActive(false);
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
