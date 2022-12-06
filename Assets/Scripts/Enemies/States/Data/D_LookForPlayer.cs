/*************************************************************** 
*file: D_LookForPlayer.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: Data version of the LookForPlayerState script where
*it sets the values of flip and the time in between those flips.
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "newLookForPlayerStateData", menuName = "Data/State Data/Look For Player Detected State")]

//inherits from scriptableobject and set the turns and time between to a set value.
public class D_LookForPlayer : ScriptableObject
{
    public int amountofTurns = 2;
    public float timeBetweenTurns = 0.75f;
}
