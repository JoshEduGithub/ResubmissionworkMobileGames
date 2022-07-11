using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    public Vector3 power;
    public Rigidbody ballRb;
    public ScoreUI Score;
    public ScoreUI Score2;
    public GameObject ball;
    public GameObject ballSpawner;
    private Vector3 ballSpawnerPos;
    private int maxSpeed = 5;
    private int minSpeed = 4;
    // Start is called before the first frame update
    void Start()
    {
        ballRb.AddForce(power, ForceMode.Impulse);
        
    }

    private void Awake()
    {
        ballSpawnerPos = ballSpawner.transform.position;
    }

    void FixedUpdate()
    {
        if (ballRb.velocity.magnitude > maxSpeed)
        {
            ballRb.velocity = ballRb.velocity.normalized * maxSpeed;
        }

        if (ballRb.velocity.magnitude < minSpeed)
        {
            ballRb.velocity = ballRb.velocity.normalized * minSpeed;
        }
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
