using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{

    static float Player1Score;
    static float Player2Score;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI ScoreText2;

    // Start is called before the first frame update
    void Start()
    {
        Player1Score = 0;
        Player2Score = 0;
    }

    public void ScoreCount(int Score)
    {
        Player1Score+= Score;
        
        ScoreText.text = "" + Player1Score;
    }

    public void ScoreCount2(int Score2)
    {
       
        Player2Score+= Score2;
        
        ScoreText2.text = "" + Player2Score;
    }
}
