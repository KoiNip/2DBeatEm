using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField] private float speed = 10;
    [SerializeField] private float jumpForce = 10;
    private int numOfJumps = 1; //Number of jumps player should have
    private int jumpCount;  //Keeps track of number of jumps player has used
    Rigidbody2D body;
    private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    IWeapon weapon;  //Weapon to use
    GameObject hitbox;
    BoxCollider2D hitboxCollider;

    //Indexes for attacks
    int a1;
    int a2;
    int a3;
    int a4;
    int a5;
    int a6;
    int attackIndex;

    //Values for attack timer/combo cooldown
    float attackTimeout = 1f;
    float attackTimer;
    bool attackTimerActive;

    //Attack values
    float _xHitBox;
    float _yHitBox;
    int _damage;
    Vector2 _direction;

    // Start is called before the first frame update
    void Start()
    {
        //Set values for player
        body = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");    //Ground check is a separate object, have to find the transform of that object
        jumpCount = numOfJumps;

        //Find attack hitbox and object
        hitbox = GameObject.Find("Hitbox");
        hitboxCollider = hitbox.GetComponent<BoxCollider2D>();

        //Initialize weapon
        weapon = new WeaponSword();  //Initializes all the attacks

        //Timer values
        attackTimer = attackTimeout;
        attackTimerActive = false;

        //Keeps track of which attack we are at (x, xx, xxx etc)
        attackIndex = 0;

        //Set all attack values to 0 (No attack) to start
        a1 = 0;
        a2 = 0;
        a3 = 0;
        a4 = 0;
        a5 = 0;
        a6 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);  //Applies velocity to the player
        Jump();
        attack();
    }

    //Code to run when jumping
    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && IsGrounded()) //Jump functionality
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            //Sets animator trigger to jump so it knows to play jumping animation
            //jumpAnimDisable = false;
        }
        else if(Input.GetButtonDown("Jump") && jumpCount > 0)   //Use extra jump
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            jumpCount--;
        }
        if(IsGrounded())    //If grounded, refresh extra jump
        {
            jumpCount = numOfJumps;
        }

        /*if(!IsGrounded())   //If we aren't on the ground, play jump animation. Works for falling too
        {
            anim.SetTrigger("jump");
        }*/

        //Allow us to hold the jump button to go higher
        if(Input.GetButtonUp("Jump") && body.velocity.y > 0f)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * 0.5f);
        }
    }

    void attack()
    {
        if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
            attackTimerActive = true;
            attackTimer = attackTimeout;
        }

        if(attackTimerActive)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                setAttackIndecies(1);
                attackIndex++;
            }
            if(Input.GetButtonDown("Fire2"))
            {
                setAttackIndecies(2);
                attackIndex++;
            }
            attackTimer -= Time.deltaTime;
        }

        //If timer ends, or we attack 6 times, reset moves back to beginning
        if(attackTimer <= 0.0f || attackIndex >= 6)
        {
            attackTimer = attackTimeout;
            attackTimerActive = false;
            attackIndex = 0;
            print(a1);
            print(a2);
            print(a3);
            print(a4);
            print(a5);
            print(a6);
            a1 = 0;
            a2 = 0;
            a3 = 0;
            a4 = 0;
            a5 = 0;
            a6 = 0;
            hitboxCollider.size = new Vector2(0, 0);
        }

        //weapon.attacks[a1, a2, a3, a4, a5, a6]
        //If the current attack exsists (Has been programmed), get it's values for attack
        if(weapon.attacks[a1, a2, a3, a4, a5, a6].isValid)
        {
            weapon.attacks[a1, a2, a3, a4, a5, a6].setAttackValues(ref _xHitBox, ref _yHitBox, ref _damage, ref _direction);
            hitboxCollider.size = new Vector2(_xHitBox, _yHitBox);
        }

    }

    private void setAttackIndecies(int attackValue)
    {
        switch (attackIndex)
        {
            case 0:
                a1 = attackValue;
                break;
            case 1:
                a2 = attackValue;
                break;
            case 2:
                a3 = attackValue;
                break;
            case 3:
                a4 = attackValue;
                break;
            case 4:
                a5 = attackValue;
                break;
            case 5:
                a6 = attackValue;
                break;
        }
            

    }

    //Better way to tell if we're grounded
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);    //Creates invisible circle at player feet, when collding with ground will return true
    }
}
