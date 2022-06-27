using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{

    public static bool paused;
    [TooltipAttribute("Reference to the pause menu game object in the scene")]
    // getting the pause menu game object to interact with TMPbuttons and enable toggling of visiblity through code
    public GameObject pauseMenu;

    void Start()
    {
        // makes sure the game isn't paused when the scene is loaded
        PauseGame(false);
    }




    public void Restart()
    {
        // reloads the active level to restart the game. 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame(bool isPaused)
    {
        paused = isPaused;

        // if the game is paused timescale is 0, if active is 1

        if (paused == true)
        {
            //Debug.Log("Paused");
            Time.timeScale = 0;
        }
        else if (paused == false)
        {
            //Debug.Log("Unpaused");
            Time.timeScale = 1;
        }
    }

    // loads the specified scene when called
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // exit the game when called

    public void exitGame()
    {
        Application.Quit();
    }

    public void setQuality(int qualityIndx)
    {
        QualitySettings.SetQualityLevel(qualityIndx);
    }

}
