using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*************************************************************** 
*file: IWeapon.cs
*author: Corey Nambu
*class: CS 4700 – Game Development 
*assignment: Program 4
*date last modified: 12/5/2022
* 
*purpose: This interface was created for the purpose of extensibility. Using this interface, we can do a dynamic polymorphic call
* in the player controller so that our code works for any weapon we create, effectivly allowing us to easily make multiple weapons
* with different attacks.
* 
****************************************************************/ 
public interface IWeapon
{
    Attack[,,,,,] attacks{get;}
}
