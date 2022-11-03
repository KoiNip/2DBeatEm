using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //Body, input, and ground check for basic player controller
    Rigidbody2D body;
    private float horizontalInput;
    private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    //Values for double jump
    private int numOfJumps = 1; //Number of jumps player should have
    private int jumpCount;  //Keeps track of number of jumps player has used

    //Speed and jump stats
    [SerializeField] private float speed = 10;
    [SerializeField] private float jumpForce = 10;

    //Weapon body and hitbox
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
    float xPos;
    float yPos;
    float uptime;

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
        //Get input and apply corresponding velocity to player
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //Perform jumps and attacks
        Jump();
        attack();
    }

    //Code to run when jumping
    private void Jump()
    {
        //Jump functionality
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            //Sets animator trigger to jump so it knows to play jumping animation
            //jumpAnimDisable = false;
        }
        //Use extra jump
        else if(Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            jumpCount--;
        }
        //Allow us to hold the jump button to go higher
        if(Input.GetButtonUp("Jump") && body.velocity.y > 0f)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * 0.5f);
        }

        //If grounded, refresh double jump
        if(IsGrounded())
        {
            jumpCount = numOfJumps;
        }

        //For animations, may not be used
        /*if(!IsGrounded())   //If we aren't on the ground, play jump animation. Works for falling too
        {
            anim.SetTrigger("jump");
        }*/
    }

    void attack()
    {
        //If attack input is sent, start timer
        if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
            attackTimerActive = true;
            attackTimer = attackTimeout;
        }

        //If timer is active, get input and set corresponding variables to determine attack
        if(attackTimerActive)
        {
            //Light attack
            if(Input.GetButtonDown("Fire1"))
            {
                setAttackIndecies(1);
                attackIndex++;
            }
            //Heavy attack
            if(Input.GetButtonDown("Fire2"))
            {
                setAttackIndecies(2);
                attackIndex++;
            }

            //Reduce timer every tick it is active
            attackTimer -= Time.deltaTime;
        }

        //If timer ends, or we attack 6 times, reset moves back to beginning
        if(attackTimer <= 0.0f || attackIndex >= 6)
        {
            attackTimer = attackTimeout;
            attackTimerActive = false;
            attackIndex = 0;
            a1 = 0;
            a2 = 0;
            a3 = 0;
            a4 = 0;
            a5 = 0;
            a6 = 0;
            hitboxCollider.size = new Vector2(0, 0);
        }

        //If the current attack exsists (Has been programmed), get it's values for attack
        if(weapon.attacks[a1, a2, a3, a4, a5, a6] != null)
        {
            weapon.attacks[a1, a2, a3, a4, a5, a6].setAttackValues(ref _xHitBox, ref _yHitBox, ref _damage, ref _direction);
            hitboxCollider.size = new Vector2(_xHitBox, _yHitBox);
        }
    }

    //Used to set the attack indecies, sets what attack is being used
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
        //Creates invisible circle at player feet, when collding with ground will return true
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
