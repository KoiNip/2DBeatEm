using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "newLookForPlayerStateData", menuName = "Data/State Data/Look For Player Detected State")]

public class D_LookForPlayer : ScriptableObject
{
    public int amountofTurns = 2;
    public float timeBetweenTurns = 0.75f;
}
