using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*************************************************************** 
*file: HealthBarScript
*author: Corey Nambu
*class: CS 4700 – Game Development 
*assignment: Program 4
*date last modified: 12/5/2022
* 
*purpose: This script is used to control the health bar, we can call these functions to set the value
* the health bar should display from the player controller to make it increment/decrement
* 
****************************************************************/ 
public class HealthBarScript : MonoBehaviour
{
    public Slider slider;

    //Set the max health of the healthbar, and set current health equal to max health
    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //Set the current health to display in the health bar
    public void setHealth(float health)
    {
        slider.value = health;
    }
}
