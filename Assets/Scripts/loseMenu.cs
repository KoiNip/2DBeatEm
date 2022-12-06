/*
 * File: loseMenu.cs
 * Author - Ryan Phan
 * Class - CS 4700 Game Development
 * Assignment - Program 4
 * Date Last Modified: 12/5/2022
 * 
 * Purpose: Gives functionality to the Lose Screen.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loseMenu : MonoBehaviour
{
    public GameObject deathMenu;

    //Function to display the menu
    public void setMenu()
    {
        deathMenu.SetActive(true);
    }

    //Functionality for the retry button
    public void retryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    //Functionality to go to main menu
    public void loadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }    

    //To quit game
    public void quitGame()
    {
        Application.Quit();
    }

}
