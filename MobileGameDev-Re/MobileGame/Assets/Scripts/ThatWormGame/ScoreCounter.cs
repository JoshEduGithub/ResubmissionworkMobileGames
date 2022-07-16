using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI tScore;
    public TextMeshProUGUI hScore;
    private static float wormscore;
    private float HighScore;


    void Start()
    {
       wormscore = 0;
       // loads the players highest score when the scene opens
       HighScore = PlayerPrefs.GetFloat("highScore", HighScore);
       hScore.text = "Best: " + HighScore.ToString();

    }

    void Update()
    {
        if (wormscore > HighScore)
        {   
            // setting the high score to the players 
            HighScore = wormscore;
            // writing high score to gui
            hScore.text = "Best: " +  HighScore;
            // where the score will be saved
            PlayerPrefs.SetFloat("highScore", HighScore);
            // save the score to file
            PlayerPrefs.Save();
            
        }
    }
    public void food(int _food)
    {
        // increase score when get food
        wormscore += _food;
        // writes score to gui
        tScore.text = "SCORE: " + wormscore;
    }

}
