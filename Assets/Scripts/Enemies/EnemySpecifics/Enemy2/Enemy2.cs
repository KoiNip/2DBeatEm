using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Entity
{
	public E2_IdleState idleState { get; private set; }
	public E2_MoveState moveState { get; private set; }
	public E2_PlayerDetectedState playerDetectedState { get; private set; }
	public E2_LookForPlayer lookForPlayerState { get; private set; }
	public E2_RangedAttackState rangedAttackState { get; private set; }
	protected bool isGrounded;
	[SerializeField] private D_IdleState idleStateData;
	[SerializeField] private D_MoveState moveStateData;
	[SerializeField] private D_PlayerDetected playerDetectedData;
	[SerializeField] private D_LookForPlayer lookForPlayerStateDate;
	[SerializeField] private D_RangedAttackState rangedAttackStateData;

	[SerializeField] private Transform rangedAttackPosition;

	//health, stored damage, rigidbody, and player object damage
	private float health = 100f; 
	private float damage = 30f;
	Rigidbody2D body;
	
	private GameObject player;

	public override void Start()
    {
		base.Start();

		moveState = new E2_MoveState(this, stateMachine, "move", moveStateData, this);
		idleState = new E2_IdleState(this, stateMachine, "idle", idleStateData, this);
		playerDetectedState = new E2_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
		lookForPlayerState = new E2_LookForPlayer(this, stateMachine, "lookForPlayer", lookForPlayerStateDate, this);
		rangedAttackState = new E2_RangedAttackState(this, stateMachine, "rangedAttack", rangedAttackPosition, rangedAttackStateData, this);

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
