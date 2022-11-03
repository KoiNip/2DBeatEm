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
        _attacks[1, 0, 0, 0, 0, 0] = new Attack(40, 40, 10, 10, 10);    //Light attack
        _attacks[1, 1, 0, 0, 0, 0] = new Attack(50, 50, 10, 20, 10);    //Two light attacks
        _attacks[2, 0, 0, 0, 0, 0] = new Attack(80, 80, 10, 20, 20);    //One heavy attack
        print("it worked");
    }

    public void initialize()
    {
        
    }
}
