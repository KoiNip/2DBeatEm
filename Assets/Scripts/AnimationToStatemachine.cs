/*************************************************************** 
*file: AnimationToStatemachine.cs 
*author: T. Diaz 
*class: CS 4700 – Game Development 
*assignment: program 4 
*date last modified: 12/04/2022
* 
*purpose: To make an tranistion for the attack to the state
*machine.
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStatemachine : MonoBehaviour
{
    public AttackState attackState;

    //creates the beginning of the attack state
    private void TriggerAttack()
    {
        attackState.TriggerAttack();
    }

    //finishes the animation of the attack state
    private void FinishAttack()
    {
        attackState.FinishAttack();
    }
}