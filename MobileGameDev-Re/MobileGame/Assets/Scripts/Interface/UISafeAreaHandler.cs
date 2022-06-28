using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tutorial demonstrating the use of code to manage notches on mobile devices
// by creating a screen safe area.
// Chapter 4 slide 60
// Chapter 4 : Resolution-Independent UI
// CMP6187 – Mobile Game Development

public class UISafeAreaHandler : MonoBehaviour
{
    RectTransform panel;
    // Start is called before the first frame update
    void Start()
    {
        panel = GetComponent<RectTransform>();
    }

    void Update()
    {
        Rect area = Screen.safeArea;

        // Pixel size in screen space of the whole screen
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);

        if (Application.isEditor && Input.GetButton("Jump"))
        {
            if (Screen.height > Screen.width)
            {
                // portrait
                area = new Rect(0f, 0.038f, 1f, 0.913f);
            }
            else
            {
                // landscape
                area = new Rect(0.049f, 0.051f, 0.902f, 0.949f);
            }

            panel.anchorMin = area.position;
            panel.anchorMax = (area.position + area.size);

               
            return;
        }
    
        // set anchors to percentages of the screen used.
        panel.anchorMin = area.position / screenSize;
        panel.anchorMax = (area.position + area.size) / screenSize;
    }
}
