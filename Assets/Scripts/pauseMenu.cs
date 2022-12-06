/*
 * File: pauseMenu.cs
 * Author - Ryan Phan
 * Class - CS 4700 Game Development
 * Assignment - Program 4
 * Date Last Modified: 12/5/2022
 * 
 * Purpose: Giving functionality to the pause menu.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool isGamePause = false;

    public GameObject pauseUI;

    // Update is called once per frame
    //Checking if game is paused
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePause)
                resumeGame();
            else
                pauseGame();
        }
    }

    //Pauses the game
    public void pauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        isGamePause = true;
    }

    //Unpauses the game
    public void resumeGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        isGamePause = false;
    }

    //Change the scene to 'Main Menu'
    public void goMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

    //Quit the game
    public void quitGame()
    {
        Application.Quit();
    }


}
