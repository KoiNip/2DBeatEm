using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class meunOptions : MonoBehaviour
{
    public void playButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
