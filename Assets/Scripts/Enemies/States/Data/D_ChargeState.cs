/*************************************************************** 
*file: D_ChargeState.cs
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: Data version of the ChargeState script where it sets
*the values of the charge speed and time of the enemy.
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newChargeStateData", menuName = "Data/State Data/Charge State")]

//inherits from scriptableobject and set the speed of the charge and the time of the charge to a set value.
public class D_ChargeState : ScriptableObject
{
    public float chargeSpeed = 6f;

    public float chargeTime = 2f;
}
