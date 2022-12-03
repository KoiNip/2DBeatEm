using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    [Header ("For Jump Attack")]
    [SerializeField] float jumpHeight;
    [SerializeField] Transform player;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Vector2 boxSize;

    [Header ("For to see Player")]
    [SerializeField] Vector2 lineOfSite;
    [SerializeField] LayerMask playerLayer;
    private bool canSeePlayer;

    [Header ("Other")]
    private Animator enemyAnim;
    private Rigidbody2D enemyRB;

    private bool isGrounded;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundLayer);
        canSeePlayer = Physics2D.OverlapBox(transform.position, lineOfSite, 0, playerLayer);
        AnimationController();
    }

    void JumpAttack()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;

        if(isGrounded)
        {
            enemyRB.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);
        }
    }

    void AnimationController()
    {
        enemyAnim.SetBool("canSeePlayer", canSeePlayer);
        enemyAnim.SetBool("isGrounded", isGrounded);
    }

}
