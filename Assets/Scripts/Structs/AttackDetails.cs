/*************************************************************** 
*file: AttackDetails.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: The details of the attack, the postion of the attack
*and the damage amount.
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//sets a vector 2 of the position and a float of the damageAmount
public struct AttackDetails
{
    public Vector2 position;
    public float damageAmount;
} 

