using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSword: IWeapon
{
    
    Attack[,,,,,] _attacks = new Attack[3, 3, 3, 3, 3, 3];
    
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
        _attacks[1, 0, 0, 0, 0, 0] = new Attack(2.5f, 2f, 10, 3, 3, 0f, .3f, 0f, 0.5f);    //Light attack
        _attacks[1, 1, 0, 0, 0, 0] = new Attack(3, 3, 10, 3, 3, 0f, 0f, 0f, 0.5f);    //Two light attacks
        _attacks[1, 1, 1, 0, 0, 0] = new Attack(5, 5, 15, 10, 10, 0f, 0f, 0f, 0.5f);    //Three light attacks

        _attacks[2, 0, 0, 0, 0, 0] = new Attack(6, 4, 10, 10, 10, 0f, 0f, 0f, 0.5f);    //One heavy attack
        _attacks[2, 2, 0, 0, 0, 0] = new Attack(7, 4, 15, 15, 10, 0f, 0f, 0f, 0.5f);
        _attacks[2, 2, 2, 0, 0, 0] = new Attack(9, 6, 25, 25, 5, 0f, 0f, 0f, 0.5f);    //triple heavy is suppose to create room by knocking enemies backwards

       //Knock ups
        _attacks[1, 1, 2, 0, 0, 0] = new Attack(6, 8, 15, 5, 25, 0f, 0f, 0f, 0.5f);    //Ideal knockup combo - suppose to act as a way to knock them up - send them to the moon
        _attacks[2, 1, 0, 0, 0, 0] = new Attack(4, 6, 10, 5, 8, 0f, 0f, 0f, 0.5f);     //A weaker knock up
        _attacks[2, 1, 1, 0, 0, 0] = new Attack(5, 8, 13, 5, 13, 0f, 0f, 0f, 0.5f);    //Follow up for combo - knocks them up
        _attacks[2, 1, 2, 0, 0, 0] = new Attack(6, 8, 15, 5, -15, 0f, 0f, 0f, 0.5f);    //Follow up combo - knocks them back down

        _attacks[1, 1, 2, 0, 0, 0] = new Attack(6, 9, 15, 5, 25, 0f, 0f, 0f, 0.5f);

    }
}
