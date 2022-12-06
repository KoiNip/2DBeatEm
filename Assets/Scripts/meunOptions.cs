/*
 * File: menuOptions.cs
 * Author - Ryan Phan
 * Class - CS 4700 Game Development
 * Assignment - Program 4
 * Date Last Modified: 12/5/2022
 * 
 * Purpose: Gives functionality to the main menu.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class meunOptions : MonoBehaviour
{
    //To play the game
    public void playButton()
    {
        SceneManager.LoadScene("Level1");
    }

    //to quit the game
    public void quitButton()
    {
        Application.Quit();
    }
}
