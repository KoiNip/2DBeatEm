using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState idleState {get; private set; }
    public E1_MoveState moveState {get; private set; }
    public E1_PlayerDetectedState playerDetectedState {get; private set; }
    public E1_ChargeState chargeState {get; private set; }
    public E1_LookForPlayer lookForPlayerState {get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_PlayerDetected playerDetectedData;
    [SerializeField] private D_ChargeState chargeStateData;
    [SerializeField] private D_LookForPlayer lookForPlayerStateDate;

    private float health = 100f;    //Health each enemy has
    private float damage = 30f; //Stores damage dealt
    Rigidbody2D body;   //Stores enemy rigid body for knockback
    private GameObject player;  //Stores player object to be damaged

    public override void Start()
    {
        base.Start();

        moveState = new E1_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E1_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E1_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new E1_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new E1_LookForPlayer(this, stateMachine, "lookForPlayer", lookForPlayerStateDate, this);

        stateMachine.Initialize(moveState);
        
        GameObject getBody = GameObject.Find("Alive");
        body = getBody.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    void update()
    {
        if(player.GetComponent<playerController>().playerEnteredTrigger)
        {
            //Do player damage here
            print("It worked");
        }
    }

    public void takeDamage(float damage, Vector2 knockback)
    {
        body.velocity = knockback;
        health -= damage;

        if(health <= 0)
        {
            print("Enemy killed!");
            Destroy(this);
        }
    }
}
