using UnityEngine;
using System.Collections;
/*************************************************************** 
*file: EnemyHealth.cs
*author: Ryley Gonzales
*class: CS 4700 – Game Development 
*assignment: Program 4
*date last modified: 12/5/2022
* 
*purpose: Script works with the ranged enemy animator to set animated states,
* the health value would go unused in favor of the enemy hitbox scripts
* 
****************************************************************/ 
public class EnemyHealth : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    //Deal damage to the enemy, not used in favor of enemy hitbox scripts
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");

                //Deactivate all attached component classes
                foreach (Behaviour component in components)
                    component.enabled = false;

                dead = true;
            }
        }
    }

    //Deactivate enemy when killed
    public void Deactivate()
	{
        gameObject.SetActive(false);
    }
}