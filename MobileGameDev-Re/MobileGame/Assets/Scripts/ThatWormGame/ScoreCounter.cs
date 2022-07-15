using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI tScore;
    private static float wormscore;


    void Start()
    {
       wormscore = 0;

    }
    public void food(int _food)
    {
        wormscore += _food;

        tScore.text = "SCORE: " + wormscore;
    }

}
