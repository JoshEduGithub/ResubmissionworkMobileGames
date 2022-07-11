using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation; // AR Raycast Manager
using UnityEngine.XR.ARSubsystems; // Trackable type

public class PlaceARObject : MonoBehaviour
{
    // Chapter 12: Augmented Reality. Apart of the "BuildingYourOwnGame" mobile game development tutorial series

    // Reference to the raycast manager to perform AR raycasts
    ARRaycastManager raycastManager;

    // Reference to the AR camera
    Camera arCamera;

    public GameObject objectSpawn;

    private void Start()
    {
        // Finding the AR raycast manager attached to the AR Session origin component
        raycastManager = GameObject.FindObjectOfType<ARRaycastManager>();
        // Finding the AR camera attached to the Ar Session origin component
        arCamera = GameObject.FindObjectOfType<Camera>();

    }

    private void LateUpdate()
    {
        // get the center of the screen
        var viewportCenter = new Vector2(0.5f,0.5f);
        var screenCenter = arCamera.ViewportToScreenPoint(viewportCenter);

        // check if something is infront of the center of the screen
        UpdateIndicator(screenCenter);


        //LandscapeGame();
    }


    // Updates the placement indicator's position and rotation to be on the floor of plane surface

    private void UpdateIndicator(Vector2 screenPosition)
    {
        var hits = new List<ARRaycastHit>();

        raycastManager.Raycast(screenPosition,hits,TrackableType.Planes);

        // check if hit point
        if (hits.Count > 0)
        {
            // get the pose data
            var placementPose = hits[0].pose;
            var camForward = arCamera.transform.forward;
            // flat object
            //camForward.y = 0;
            // scale vector to be size of 1
            camForward = camForward.normalized;

            // rotate to face in front of camera player always see object
            placementPose.rotation = Quaternion.LookRotation(camForward);

            // places slightly above plane
            var newPosition = placementPose.position;
            newPosition.y += 0.003f;

            transform.SetPositionAndRotation(newPosition,placementPose.rotation);

        }
    }

    private void LandscapeGame()
    {
        // creates an instance of the game if the phone is landscape
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
        {
            Vector3 objPos = transform.position + Vector3.up;

            if(objectSpawn)
            {
                Instantiate(objectSpawn, objPos, transform.rotation);
            }
        }

        if (Input.deviceOrientation == DeviceOrientation.Portrait)
        {
            Destroy(objectSpawn);
        }
    }

    
}
