using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*** 
*file: Finish.cs 
*author: Flor Hernandez 
*class: CS 4700 – Game Development 
*assignment: Final Project 
*date last modified: 12/5/2022 
* 
*purpose: This code calls the next scene in the build settings 
*once the player reaches an object that is triggered. The player
*will spawn in the next scene in the build index.
* 
**/

public class Finish : MonoBehaviour
{
    //private AudioSource finishSound:
    private bool levelCompleted = false;
    // Start is called before the first frame update
    private void Start()
    {
       // finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            //finishSound.Play();
            levelCompleted = true;
           Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
