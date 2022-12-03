using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitboxScripts : MonoBehaviour
{
    public float health = 100f;    //Health each enemy has
    public float damage = 30f; //Stores damage dealt
    Rigidbody2D body;   //Stores enemy rigid body for knockback
    private GameObject player;  //Stores player object to be damaged
    // Start is called before the first frame update
    void Start()
    {
        //Bodies and players for dealing and taking damage
        GameObject getBody = GameObject.Find("Alive");
        body = getBody.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

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

    //Deal damage to player
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other != null)    //If we aren't invincible when we get hit, set player Entered to true
        {
            Collider2D collider = other.collider;    //Find collider of colliding object
            Rigidbody2D otherBody = collider.GetComponent<Rigidbody2D>();   //Find Rigid body of colliding object

            BoxCollider2D hitbox = GetComponentInChildren<BoxCollider2D>();
            if(other.gameObject.tag == "Player")
            {
                if(!player.GetComponent<playerController>().isInvincible)
                {
                    player.GetComponent<playerController>().isInvincible = true;
                    player.GetComponent<playerController>().invinTimer = player.GetComponent<playerController>().maxInvinceTime;
                    player.GetComponent<playerController>().health -= damage;
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 1f);
                    print(player.GetComponent<playerController>().health);
                }
            }
        }
    }
}
