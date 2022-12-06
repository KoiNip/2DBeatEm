/*************************************************************** 
*file: D_MeleeAttack.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: Data version of the MeleeAttackState script where it
*sets set values for the attack radius and damage of the enemy.
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMeleeAttackStateData", menuName = "Data/State Data/Melee Attack Data")]

//inherits from scriptableobject and set the radius and damage to a set value.
public class D_MeleeAttack : ScriptableObject
{
   public float attackRadius = 0.5f;
   public float attackDamage = 10f;

   public LayerMask whatIsPlayer;
}
