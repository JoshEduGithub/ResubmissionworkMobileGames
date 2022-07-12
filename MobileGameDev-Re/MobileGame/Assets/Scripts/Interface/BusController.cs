using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusController : MonoBehaviour
{

    private FMOD.Studio.Bus busAController;
    public string busName;

    [SerializeField] private float busVolume;

    private Slider slider;


    void Start()
    {
        busAController = FMODUnity.RuntimeManager.GetBus("bus:/" + busName);
        slider = GetComponent<Slider>();
        busAController.getVolume(out busVolume);
    }

    public void setVolume(float volume)
    {
        busAController.setVolume(volume);
        busAController.getVolume(out busVolume);
    }

    
}
