using UnityEngine;

/*************************************************************** 
*file: EnemyArrowHolders.cs
*author: Ryley Gonzales
*class: CS 4700 – Game Development 
*assignment: Program 4
*date last modified: 12/5/2022
* 
*purpose: This script interfaces with the child arrows that are shot at the player.
* It is used by the internal ranged enemy to shoot the arrows
* 
****************************************************************/ 
public class EnemyArrowHolder : MonoBehaviour
{
    [SerializeField] private Transform enemy;

    //Update is called once per frame
    private void Update()
    {
		if (enemy != null)
		{
        	transform.localScale = enemy.localScale;
		}
    }
}