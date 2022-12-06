/*************************************************************** 
*file: D_MoveState.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: Data versiom of the Move State script where it 
*sets the value of the movement of the enemy
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMoveStateData", menuName = "Data/State Data/Move State")]

//inherits from scriptableobject and set the speed to a set value.
public class D_MoveState : ScriptableObject
{
    public float movementSpeed = 3f;
}
