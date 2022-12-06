using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*************************************************************** 
*file: Attack.cs
*author: Corey Nambu
*class: CS 4700 – Game Development 
*assignment: Program 4
*date last modified: 12/5/2022
* 
*purpose: This is the attack class, it defines the stats for an attack. This class was created
* to allow us to easily create more attacks without having to write a lot of code. This class holds
* all the stats we need for an attack, including damage, knockback, hitbox position and size, attack uptime
* and endlag, and whether the attack is the last attack in the combo, allowing for a new combo to start
* 
****************************************************************/ 
public class Attack
{
    float _xHitBox;
    float _yHitBox;
    float _damage;
    Vector2 _direction;
    float _endlag = 0.0f;
    float _xPos;
    float _yPos;
    float _upTime;
    bool isFinal;

    //Constructore, makes the attack object
    public Attack(float xHit, float yHit, float damage, float xKnockback, float yKnockback, float xPos, float yPos, float endlag, float upTime, bool isFinal)
    {
        this._xHitBox = xHit;
        this._yHitBox = yHit;
        this._damage = damage;
        this._direction = new Vector2(xKnockback, yKnockback);
        this._endlag = endlag;
        this._xPos = xPos;
        this._yPos = yPos;
        this._upTime = upTime;
        this.isFinal = isFinal;
    }

    /*  Sets the values for the attack in the player controller
    *   Takes ref's as we set the ref's equal to the values stored in attack
    *
    */
    public void setAttackValues(ref float xHit, ref float yHit, ref float damage, ref Vector2 direction, ref float xpos, ref float ypos, ref float endlag, ref float uptime, ref bool isFinal)
    {   
        xHit = this._xHitBox;
        yHit = this._yHitBox;
        damage = this._damage;
        direction = this._direction;
        xpos = this._xPos;
        ypos = this._yPos;
        endlag = this._endlag;
        uptime = this._upTime;
        isFinal = this.isFinal;
    }

    //Gets the uptime, not used in favor of set attack values
    public float getUptime()
    {
        return _upTime;
    }
}
