using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{

    public UserInterface Score;
    public UserInterface Score2;
    public GameObject ball;
    public GameObject ballSpawner;
    private Vector3 ballSpawnerPos;

    private void Awake()
    {
        ballSpawnerPos = ballSpawner.transform.position;
    }
    


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "PongPlayer1Goal")
        {
            
            Score.ScoreCount(+1);
            // respawns the ball
            ball.transform.position = ballSpawnerPos;
            
        }
        else if (col.gameObject.tag == "PongPlayer2Goal")
        {
            
            Score2.ScoreCount2(+1);
            ball.transform.position = ballSpawnerPos;
        }

    }

    
}
