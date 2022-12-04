using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    *
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

    public float getUptime()
    {
        return _upTime;
    }
}
