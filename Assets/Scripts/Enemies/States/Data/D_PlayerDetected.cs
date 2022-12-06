/*************************************************************** 
*file: D_PlayerDetected.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose:Data version of the player detected script where it 
*provides the values for the player detected state.
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "newPlayerDetectedData", menuName = "Data/State Data/Player Detected State")]

//inherits from scriptableobject and set the longrange action time to a set value.
public class D_PlayerDetected : ScriptableObject
{
    public float longRangeActionTime = 1.5f;
}
