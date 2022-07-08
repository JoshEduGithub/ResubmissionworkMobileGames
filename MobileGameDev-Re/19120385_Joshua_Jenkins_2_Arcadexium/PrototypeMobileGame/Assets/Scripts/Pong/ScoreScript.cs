using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{

    public UserInterface Score;
    public UserInterface Score2;

    public GameObject ball;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "PongPlayer1Goal")
        {
            
            Score.ScoreCount(+1);
            ball.transform.position = new Vector3(0,-5.1500001f,27.5f);
            
        }
        else if (col.gameObject.tag == "PongPlayer2Goal")
        {
            
            Score2.ScoreCount2(+1);
            ball.transform.position = new Vector3(0,-5.1500001f,27.5f);
        }

    }

    
}
