using UnityEngine;
/*************************************************************** 
*file: RangedEnemy.cs
*author: Ryley Gonzales
*class: CS 4700 – Game Development 
*assignment: Program 4
*date last modified: 12/5/2022
* 
*purpose: This script detects the player and shoots at them if they are found.
* handles the animations, player detection, and preparing arrows for shooting
* 
****************************************************************/ 
public class RangedEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Ranged Attack")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] arrow;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    //References
    private Animator anim;
    private EnemyPatrol enemyPatrol;

    //Called at start of game
    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    //Called every frame
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight?
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("rangedAttack");
            }
        }
        else
        {
            anim.SetBool("rangedAttack", false);
        }

        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
            print(enemyPatrol.enabled);
        }
    }

    //Performs the ranged attack
    private void RangedAttack()
    {
        cooldownTimer = 0;
        arrow[FindArrows()].transform.position = firepoint.position;
        arrow[FindArrows()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }
    //Finds the children arrows for use in the attacks
    private int FindArrows()
    {
        for (int i = 0; i < arrow.Length; i++)
        {
            if (!arrow[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    //Handles player detection, returns a bool for if player was detected
    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }
    //Draws range on screen for testing purposes
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}