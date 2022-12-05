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

    //Keeps track of if a new input has been given
    bool newAttack = false;

    //Attack values
    float _xHitBox;
    float _yHitBox;
    float _damage;
    Vector2 _direction;
    float _xPos;
    float _yPos;
    float _endlag;
    float _uptime;
    bool isFinal;

    //Animation Stuff
    private Animator anim;
    int attackRNG;

    //Sound Stuff
    private AudioSource audioSource;

    //Variable used to keep track of if player has entered hitbox
    public float invinTimer;
    public float maxInvinceTime = 1f;
    public bool isInvincible = false;

    //Health
    public float health = 100f;

    //Keeps track of the direction the player is facing, used for dealing knockback to enemy
    bool facingRight;

    //Keeps track of if the player is dead
    bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        //Set values for player
        body = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");    //Ground check is a separate object, have to find the transform of that object
        jumpCount = numOfJumps;

        //Animation and Sound
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

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

        //Set invincible timer to 0 to start
        invinTimer = 0;

        //We face right by default
        facingRight = true;

        //Sets is dead, we are not dead by default
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Perform jumps and attacks
        //Pause Menu Functions
        if (!pauseMenu.isGamePause)
        {
            if(!isDead)
            {
                //Get input and apply corresponding velocity to player
                horizontalInput = Input.GetAxis("Horizontal");
                body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

                //Animation
                anim.SetBool("run", horizontalInput != 0);
                attack();
                handleFlip();
                Jump();

                //Manage the invincibility timer, decrementing as needed and setting playerEntered Trigger
                manageInvinTimer();
            }
            
            //Call game over if player dies
            if (health <= 0)
            {
                die();
            }
        }

    }

    //Code to run when jumping
    private void Jump()
    {
        //Jump functionality
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
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
            anim.SetBool("grounded", true);
        }
        else if (!IsGrounded())
        {
            anim.SetBool("grounded", false);
        }

    } 

    void attack()
    {
        //If attack input is sent, start timer
        if ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && _endlag <= 0)
        {
            attackTimerActive = true;
            attackTimer = attackTimeout;    //Resets timer even when input invalid attack, may need to fix
            newAttack = true;
        }

        //If timer is active, get input and set corresponding variables to determine attack
        if(attackTimerActive && _endlag <= 0)
        {
            //Light attack
            if(Input.GetButtonDown("Fire1"))
            {
                setAttackIndecies(1);
                attackIndex++;
                attackRNG = Random.Range(1, 5);
                if (attackIndex <= 3)
                {
                    if (attackRNG == 1)
                    {
                        anim.Play("LightAttack1");

                    }
                    else if (attackRNG == 2)
                    {
                        anim.Play("LightAttack2");
                    }
                    else if (attackRNG == 3)
                    {
                        anim.Play("LightAttack3");
                    }
                    else
                    {
                        anim.Play("LightAttack4");
                    }
                        
                }          
            }
            //Heavy attack
            if (Input.GetButtonDown("Fire2"))
            {
                setAttackIndecies(2);
                attackIndex++;

                attackRNG = Random.Range(1, 3);
                if (attackIndex <= 3)
                {
                    if (attackRNG == 1)
                        anim.Play("HeavyAttack1");
                    else if (attackRNG == 2)
                        anim.Play("HeavyAttack2");
                }  
            }

            //Reduce timer every tick it is active
            attackTimer -= Time.deltaTime;
            
        }

        //If timer ends, or we attack 6 times, reset moves back to beginning
        if(attackTimer <= 0.0f || attackIndex >= 6 || isFinal)
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
            print("Attacks reset");
            anim.SetBool("LightAttack1", false);
            isFinal = false;
        }

        //If the current attack exsists (Has been programmed), get it's values for attack
        if(weapon.attacks[a1, a2, a3, a4, a5, a6] != null && newAttack && _endlag <= 0)
        {
            weapon.attacks[a1, a2, a3, a4, a5, a6].setAttackValues(ref _xHitBox, ref _yHitBox, ref _damage, ref _direction, ref _xPos, ref _yPos, ref _endlag, ref _uptime, ref isFinal);
            newAttack = false;
            //Add endlag to attack timer so we can continue combo even if endlag would push past attack timer
            attackTimer += _endlag;
            print(a1 + a2 + a3);
        }

        //Set hitbox size and position
        if(_uptime > 0)
        {
            hitboxCollider.size = new Vector2(_xHitBox, _yHitBox);
            hitboxCollider.offset = new Vector2(_xPos, _yPos);
            _uptime -= Time.deltaTime;
        }
        else if (_uptime <= 0)  //Reset size/position after attack ends
        {
            hitboxCollider.size = new Vector2(0, 0);
            hitboxCollider.offset = new Vector2(0, 0);
        }

        //Endlag decreases once set
        if(_endlag > 0)
        {
            _endlag -= Time.deltaTime;
        }
    }

    public void playSwordSwing(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
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

    //Flips player when moving to left or right
    private void handleFlip()
    {
        if(horizontalInput < -0.01f) //Flip the player if moving to the left
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
        else if(horizontalInput > 0.01f) //Flip the player if moving to the right
        {
            transform.localScale = Vector3.one;
            facingRight = true;
        }
    }

    //Responsible for dealing damage
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other != null)
        {
            //Deal damage to enemy
            if(other.gameObject.tag == "Enemy") //Deal damage
            {
                Rigidbody2D otherBody = other.gameObject.GetComponentInChildren<Rigidbody2D>();   //Find Rigid body of colliding object
                other.gameObject.GetComponentInChildren<EnemyHitboxScripts>().health -= _damage;

                //If we are facing left, change x knockback to go to the left
                if(!facingRight)
                {
                    _direction = new Vector2(-1 * _direction.x, _direction.y);
                }
                otherBody.velocity = _direction;
                print(other.gameObject.GetComponentInChildren<EnemyHitboxScripts>().health);

                if(other.gameObject.GetComponentInChildren<EnemyHitboxScripts>().health <= 0)
                {
                    Destroy(other.gameObject);
                }
            }

            //Die to death pit
            if(other.gameObject.tag == "DeathPit")
            {
                health = 0;
            }
        }
    }

    void manageInvinTimer()
    {
        if(invinTimer > 0)  //If invincible, decrease timer
        {
            invinTimer -= Time.deltaTime;
        }
        else if (invinTimer <= 0)   //If not invincible, set bool
        {
            isInvincible = false;
        }
    }
    public loseMenu deathMenu;

    //Called when the player dies
    void die()
    {
        anim.Play("Death");
        //deathMenu.setMenu();
        isDead = true;
    }

    //Better way to tell if we're grounded
    private bool IsGrounded()
    {
        //Creates invisible circle at player feet, when collding with ground will return true
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
