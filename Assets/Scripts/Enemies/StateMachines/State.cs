/*************************************************************** 
*file: State.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose:
*
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class State
{
    protected FiniteStateMachine stateMachine;
    protected Entity entity;
    protected float startTime;
    protected string animBoolName;
    public State(Entity entity, FiniteStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }
    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(animBoolName, true);
        DoChecks();
    }

    public virtual void Exit()
    {
        if(entity !=null)
        {
            entity.anim.SetBool(animBoolName, false);
        }
    }
    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }
}
