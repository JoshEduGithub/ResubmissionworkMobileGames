using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;
using FMODUnity;

public class UserInterface : MonoBehaviour
{

    public static bool paused;
    [TooltipAttribute("Reference to the pause menu game object in the scene")]
    // getting the pause menu game object to interact with TMPbuttons and enable toggling of visiblity through code
    public GameObject pauseMenu;

    // Audio 
    private FMOD.Studio.Bus GameAudio;
    [SerializeField] private float gameVolume;



    
    void Start()
    {
        // makes sure the game isn't paused when the scene is loaded
        PauseGame(false);
        // gets volume from fmod bus
        GameAudio.getVolume(out gameVolume);
    }

    void Awake()
    {
        GameAudio = FMODUnity.RuntimeManager.GetBus("bus:/GameAudio");
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

        // displays an advertisement when switching levels
        if (AdController.showAds)
        {
            AdController.showAd();
        }
    }

    // exit the game when called

    public void exitGame()
    {
        Application.Quit();
    }

    // set the quality of the game
    public void setQuality(int qualityIndx)
    {
        QualitySettings.SetQualityLevel(qualityIndx);
    }

    // connects to the slider enabling dynamic changing of audio
    public void VolumeController (float Volume)
    {
        // set game volume
        GameAudio.setVolume(Volume);
        // save game volume
        GameAudio.getVolume(out gameVolume);
    }


}
