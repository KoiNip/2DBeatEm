/*************************************************************** 
*file: D_Entity.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: Data version of the Entity class where it sets the
*values of distances for the different kinds of checks for the
* enemy.
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]

//inherits from scriptableobject and set the wallCheck, ledgeCheck, minAgroDistance, maxAgroDistance, and closeRangeDistance to a set value.
//also creates an GameObject and LayerMasks
public class D_Entity : ScriptableObject
{
    public float wallCheckDistance = 0.2f;
    public float ledgeCheckDistance = 0.4f;

    public float minAgroDistance = 3f;
    public float maxAgroDistance = 4f;

    public float closeRangeActionDistance = 1f;

    public GameObject hitParticle;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}
