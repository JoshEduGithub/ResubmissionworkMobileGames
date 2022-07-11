using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdController : MonoBehaviour
{
    // toggle ads on off
    public static bool showAds = true;
    public string gameId = "4834491";
    // toggle testing mode
    public bool testMode = true;
    public string bannerPlacement = "bannerPlacement";

    
    // Initialises unity ads
    private void Start()
    {   
        // checks if advertisement module is active
        if(!Advertisement.isInitialized)
        {
            Advertisement.Initialize(gameId,testMode);

            StartCoroutine(EnableBanner());

        }
    }

    // Checks if there is an advertisement ready to display, if true displays advertisement when this function is called
    public static void showAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }


    IEnumerator EnableBanner()
    {
        while (!Advertisement.IsReady(bannerPlacement))
        {
            yield return new WaitForSeconds (0.5f);
        }
        Advertisement.Banner.SetPosition (BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(bannerPlacement);
    }






}
