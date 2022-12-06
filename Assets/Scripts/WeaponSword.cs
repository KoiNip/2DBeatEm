using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*************************************************************** 
*file: WeaponSword.cs
*author: Corey Nambu
*class: CS 4700 – Game Development 
*assignment: Program 4
*date last modified: 12/5/2022
* 
*purpose: This is the weapon class, it is responsible for holding all the attacks the player can use.
* each attack is an object of the attack class, stored in a 6D array for easy indexing. It may seem unusual,
* but formatting the attacks in this way allows us to completley avoid iterating through an array to see which
* attack is being called. We thoroghly looked for different ways to hold the attacks, but every other way we could
* think of would require a loop iterating through an array in some way. With this implementation, we can call an attack
* by simply saying weapon.attacks[a1, a2, a3, a4, a5, a6] in the player controller instead of looping.
* This implementation also allows for super easy attack creation, creating a new attack for the player is literally one line of code
* It does take time to make good attacks as we have to carefully balance the player and its weapon
* 
****************************************************************/ 
public class WeaponSword: IWeapon
{
    
    Attack[,,,,,] _attacks = new Attack[3, 3, 3, 3, 3, 3];
    
    //Implements the attacks from the IWeapon interface
    public Attack[,,,,,] attacks
    {
        get
        {
            return _attacks;
        }
    }

    //Class constructor, this is where we create all attacks!
    public WeaponSword()
    {
        //xhitbox size, yhitbox size, damage, xknockback, ykb, xpos, ypos, endlag, uptime
        _attacks[1, 0, 0, 0, 0, 0] = new Attack(2.5f, 2f, 10, 3, 3, 0f, .3f, 0f, 0.1f, false);    //Light attack
        _attacks[1, 1, 0, 0, 0, 0] = new Attack(3, 3, 10, 3, 3, 0f, 0f, 0f, 0.1f, false);    //Two light attacks
        _attacks[1, 1, 1, 0, 0, 0] = new Attack(5, 5, 15, 6, 6, 0f, 0f, 0f, 0.1f, true);    //Three light attacks

        _attacks[2, 0, 0, 0, 0, 0] = new Attack(6, 4, 10, 5, 5, 0f, 0f, 0f, 0.1f, false);    //One heavy attack
        _attacks[2, 2, 0, 0, 0, 0] = new Attack(7, 4, 15, 7, 5, 0f, 0f, 0f, 0.1f,false);
        _attacks[2, 2, 2, 0, 0, 0] = new Attack(9, 6, 25, 10, 5, 0f, 0f, 0f, 0.1f, true);    //triple heavy is suppose to create room by knocking enemies backwards

       //Knock ups
        _attacks[1, 1, 2, 0, 0, 0] = new Attack(6, 8, 15, 5, 10, 0f, 0f, 0f, 0.1f, true);    //Ideal knockup combo - suppose to act as a way to knock them up - send them to the moon
        _attacks[2, 1, 0, 0, 0, 0] = new Attack(4, 6, 10, 5, 6, 0f, 0f, 0f, 0.1f, false);     //A weaker knock up
        _attacks[2, 1, 1, 0, 0, 0] = new Attack(5, 8, 13, 5, 8, 0f, 0f, 0f, 0.1f, true);    //Follow up for combo - knocks them up
        _attacks[2, 1, 2, 0, 0, 0] = new Attack(6, 8, 15, 5, -8, 0f, 0f, 0f, 0.1f, true);    //Follow up combo - knocks them back down

        _attacks[1, 1, 2, 0, 0, 0] = new Attack(6, 9, 15, 5, 10, 0f, 0f, 0f, 0.1f, true);

    }
}
