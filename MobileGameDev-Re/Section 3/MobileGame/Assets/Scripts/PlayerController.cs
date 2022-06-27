using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    void FixedUpdate()
    {
        if(UserInterface.paused)
        {
            return;
        }
    }

    void Update()
    {
        if(UserInterface.paused)
        {
            return;
        }
    }
}
