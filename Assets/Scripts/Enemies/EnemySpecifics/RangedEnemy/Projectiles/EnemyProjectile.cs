using UnityEngine;

/*************************************************************** 
*file: EnemyProjectile.cs
*author: Ryley Gonzales
*class: CS 4700 – Game Development 
*assignment: Program 4
*date last modified: 12/5/2022
* 
*purpose: This script deals damage to the player when the projectile hits them,
* and also deletes itself on contact with the player.
* 
****************************************************************/ 
public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    private Animator anim;
    private BoxCollider2D coll;
	private GameObject player;

    private bool hit;
	float damage = 20f;

	void Start()
	{
		player = GameObject.FindWithTag("Player");
	}
    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    //Activates projectile when shot
    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    //Used to deal damage to player when enemy comes into contact with him
    private void OnTriggerEnter2D(Collider2D collision)
    {
		if(collision != null)
		{
			if(collision.gameObject.tag == "Player")
			{
                coll.enabled = false;
		        gameObject.SetActive(false); //When this hits any object deactivate arrow
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
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}