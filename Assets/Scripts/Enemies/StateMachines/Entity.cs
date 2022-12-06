/*************************************************************** 
*file: Entity.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: This program creates variables, gets and private sets for the other
*scripts so they can use. Plus sets those variables.
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine; //creates a finite state machine called stateMachine from the FiniteStateMachine script

    public D_Entity entityData; //creates a entity data from the D_entity script

    public int facingDirection {get; private set; } //creating an int called facingDirection with getters and private setters
    public Rigidbody2D rb {get; private set; } //creating an rigid body called rb with getters and private setters
    public Animator anim {get; private set; } //creating an animator called anim with getters and private setters
    public GameObject aliveGO {get; private set; } //creating an GameObject called aliveGO with getters and private setters
	public AnimationToStatemachine atsm { get; private set; } //calling from the AnimationToStatemachine script called atsm with getters and private setters
    public int lastDamageDirection { get; private set; } //creating an int called lastDamageDirection with getters and private setters

    [SerializeField] private Transform wallCheck; //creates a serializedfield of a private transform called wallCheck
    [SerializeField] private Transform ledgeCheck; //creates a serializedfield of a private transform called ledgeCheck
    [SerializeField] private Transform playerCheck; //creates a serializedfield of a private transform called playerCheck

    private Vector2 velocityWorkspace; //a vector2 called velocityWorkspace

    protected bool isDead; //creates a bool to see if the enemy is dead

    public virtual void Start()
    {
        facingDirection = 1; //this makes the enemy start walking to the right

        aliveGO = transform.Find("Alive").gameObject; //checks to see if there is a gameObject in Alive and if so, aliveGO will be equal to it
        rb = aliveGO.GetComponent<Rigidbody2D>(); //makes rb equal to the rigidbody of aliveGo 
        anim = aliveGO.GetComponent<Animator>(); //makes anim equal to the animator of aliveGo
		atsm = aliveGO.GetComponent<AnimationToStatemachine>(); //makes atsm equal to the AnimationToStatemachine of aliveGo

        stateMachine = new FiniteStateMachine(); //creates a new finite state machine
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate(); //updates the game every frame with the current state of the finite state machine
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate(); //updates the physics based on the frame with the current state of the finite state machine
    }
    public virtual void SetVelocity(float velocity) //creates a float named velocity in the public virtual void
    {
        velocityWorkspace.Set(facingDirection * velocity, rb.velocity.y); //this is to se the velocity of the enemy based on the facing direction and the y component of the rb
        rb.velocity = velocityWorkspace; //makes rb.velocity equal to velocityWorkspace
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, aliveGO.transform.right, entityData.wallCheckDistance, entityData.whatIsGround); //this checks if there is wall based on the wallCheck transform to make the enemy turn around
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGround); //this checks if there is a ledge based on the ldegeCheck transform to make the enemy move
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.minAgroDistance, entityData.whatIsPlayer); //this checks the playerCheck transform which if the player is in range
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer); //same as CheckPlayerInMinAgroRange, its checks the max distance that enemy can see the player
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer); //similar to the past two functions, checks if player is close to the enemy to do a melee attack
    }

    public virtual void Damage(AttackDetails attackDetails) 
    {
        if(GetComponentInChildren<EnemyHitboxScripts>().health <= 0) //checks if the enemy is health is zero
        {
            isDead = true; //if so, it sets the function isDead to true
        }
    }

    //purpose is to flip the enemy when needed to
    public virtual void Flip()
    {
        facingDirection *= -1; //sets the value to negative so enemy can flip
        if(aliveGO != null) //checks if the gameObject exists
        {
            aliveGO.transform.Rotate(0f, 180f, 0f); //rotates the gameObject the other once called
        }
    }
    

    public virtual void OnDrawGizmos()
    {
        if (rb!=null) //checks if the rb exists
        {
            Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance)); //creates a gizmos to see the wallCheck live
            Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance)); //creates a gizmos to see the ledgeCheck live
        }
    }
}


