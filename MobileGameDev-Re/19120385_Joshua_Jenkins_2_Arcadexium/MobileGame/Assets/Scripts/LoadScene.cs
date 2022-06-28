using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// https://www.youtube.com/watch?v=3qlRgICRoeA 
// video tutorial on creating a character selection system adapted into level selection on mobile device
public class LoadScene : MonoBehaviour
{
    // an object containing the available games that users can initiate
    public GameObject[] games;

    // the currently selected game in the scene
    public int gameSelected;

    void start()
    {
        gameSelected = 0;
    }
    public void nextGame()
    {
        // set the previous selected to false
        games[gameSelected].SetActive(false);
        // increases index to cycle through array of game objects
        gameSelected = (gameSelected + 1) % games.Length;
        // set the new selected game to true
        games[gameSelected].SetActive(true);
    }

    public void previousGame()
    {
        // sets active to false
        games[gameSelected].SetActive(false);
        gameSelected--;
        
        if (gameSelected < 0)
        {
            gameSelected += games.Length;
        }
        // sets new to false
        games[gameSelected].SetActive(true);
    }

    public void StartGame()
    {
        // checks to see the active game selected in array
        if (games[gameSelected])
        {
            // loads the selected scene from the array of game scenes adding 2 to compensate for main menu / level select scene
            SceneManager.LoadScene(gameSelected + 2);
            //Debug.Log(gameSelected);
        }
        

    }
}
