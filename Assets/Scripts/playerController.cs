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

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");    //Ground check is a separate object, have to find the transform of that object
        jumpCount = numOfJumps;
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
        if(Input.GetButtonDown("Fire1"))
        {
            print("Depressu");
            //Use this to change the size of the boxCollider AKA hitbox
            //collider.size = new Vector3(collider.size.x, ySize, collider.size.z);
        }
    }

    //Better way to tell if we're grounded
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);    //Creates invisible circle at player feet, when collding with ground will return true
    }
}
