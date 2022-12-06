/*************************************************************** 
*file: D_IdleState.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: Data version of the IdleState where it sets the value
*of the idle time of the enemy.
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newIdleStateData", menuName = "Data/State Data/Idle Data")]

//inherits from scriptableobject and set the max and min idle times to a set value.
public class D_IdleState : ScriptableObject
{
    public float minIdleTime = 1f;
    public float maxIdleTime = 2f;
}
