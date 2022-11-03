using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSword : MonoBehaviour, IWeapon
{
    
    Attack[,,,,,] _attacks = new Attack[3, 3, 3, 3, 3, 3];
    
    public Attack[,,,,,] attacks
    {
        get
        {
            return _attacks;
        }
    }

    public WeaponSword()
    {
        _attacks[0, 0, 0, 0, 0, 0] = new Attack(0, 0, 0, 0, 0, 0);  //Invalid attack at 0
        _attacks[1, 0, 0, 0, 0, 0] = new Attack(5, 5, 10, 3, 3);    //Light attack
        _attacks[1, 1, 0, 0, 0, 0] = new Attack(5, 5, 10, 3, 3);    //Two light attacks
        _attacks[1, 1, 1, 0, 0, 0] = new Attack(7, 7, 20, 10, 10);    //Three light attacks
        _attacks[2, 0, 0, 0, 0, 0] = new Attack(8, 8, 10, 20, 20);    //One heavy attack
        print("it worked");
    }

    public void initialize()
    {
        
    }
}
