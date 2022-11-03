using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int _xHitBox;
    int _yHitBox;
    int _damage;
    Vector2 _direction;
    int _endlag = 0;
    int _xPos;
    int _yPos;
    int _upTime;
    public bool isValid = false;

    public Attack(int xHit, int yHit, int damage, float xKnockback, float yKnockback, int endlag, int xPos, int yPos, int upTime)
    {
        this._xHitBox = xHit;
        this._yHitBox = yHit;
        this._damage = damage;
        this._direction = new Vector2(xKnockback, yKnockback);
        this._endlag = endlag;
        this._xPos = xPos;
        this._yPos = yPos;
        this._upTime = upTime;
        isValid = true;
    }

    /** Sets the basic properties of the attack, to be used when attack is used
    *   xHitbox, yHitbox, damage, knockback, direction
    *   
    */
    public Attack(int xHit, int yHit, int damage, float xKnockback, float yKnockback)
    {
        this._xHitBox = xHit;
        this._yHitBox = yHit;
        this._damage = damage;
        this._direction = new Vector2(xKnockback, yKnockback);
        isValid = true;
    }

    //0 Constructor, used to create invalid attack at 0
    public Attack(int xHit, int yHit, int damage, float xKnockback, float yKnockback, int invalid)
    {
        this._xHitBox = xHit;
        this._yHitBox = yHit;
        this._damage = damage;
        this._direction = new Vector2(xKnockback, yKnockback);
        isValid = false;    //Ensures attack does not work at 0
    }

    public void setAttackValues(ref float xHit, ref float yHit, ref int damage, ref Vector2 direction)
    {   
        xHit = this._xHitBox;
        yHit = this._yHitBox;
        damage = this._damage;
        direction = this._direction;
    }
}
