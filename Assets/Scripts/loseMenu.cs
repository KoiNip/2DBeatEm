using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loseMenu : MonoBehaviour
{
    public void retryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }    

    public void quitGame()
    {
        Application.Quit();
    }

}
