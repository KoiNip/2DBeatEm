using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool isGamePause = false;

    public GameObject pauseUI;

    // Update is called once per frame
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

    public void pauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        isGamePause = true;
    }

    public void resumeGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        isGamePause = false;
    }

    public void goMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

    public void quitGame()
    {
        Application.Quit();
    }


}
