using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;
using FMODUnity;

public class Options : MonoBehaviour
{
    // Audio 
    // reference to fmod bus
    private FMOD.Studio.Bus GameAudio;
    // active game volume visualising from Fmod Bus
    [SerializeField] private float gameVolume;
    // volume slider
    public Slider VolumeSlider;
    // Quality select dropdown
    public TMPro.TMP_Dropdown QualityDrop;

    void Awake()
    {
        // get the bus storing audio
        GameAudio = FMODUnity.RuntimeManager.GetBus("bus:/GameAudio");


    }

    void Start()
    {

        // gets volume from fmod bus
        GameAudio.getVolume(out gameVolume);
        // load the saved playerpref values
        LoadSave();

    }

    void Update()
    {
        // update the playerpreference values
        SaveOptions();

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

    // saves the options properties
    public void SaveOptions()
    {
        float SliderValue = gameVolume;
        // stores the active slider value in the file "gamevolume"
        PlayerPrefs.SetFloat("GameVolume",SliderValue);
        // stores the active dropdown value in the file "GameQuality"
        int QualSelected = QualityDrop.value;
        PlayerPrefs.SetInt("GameQuality",QualSelected);


        
    }

    // returns the saved properties
    void LoadSave()
    {
        // accessing and setting the slider properties
        float SliderValue = PlayerPrefs.GetFloat("GameVolume");
        VolumeSlider.value = SliderValue;
        // accessing and setting the dropdown properties
        int QualSelected = PlayerPrefs.GetInt("GameQuality");
        QualityDrop.value = QualSelected;
    }

}
