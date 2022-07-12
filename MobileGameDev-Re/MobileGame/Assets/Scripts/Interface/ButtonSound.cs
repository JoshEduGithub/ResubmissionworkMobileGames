using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class ButtonSound : MonoBehaviour
{
    [SerializeField]
    EventReference AudioClip;


    public void ButtonAudio()
    {
            RuntimeManager.PlayOneShot(AudioClip);
    }
}

    
