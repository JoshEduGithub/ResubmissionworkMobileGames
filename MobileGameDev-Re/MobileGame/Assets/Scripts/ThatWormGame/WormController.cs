using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://www.youtube.com/watch?v=iuz7aUHYC_E&t=239s
// Unity tutorial demonstrating how to make a snake 3D style game
// Has been adapted to use the mobile accelerator for movemement
// Further development including score, death, obstacles and other events have been added ontop.
public class WormController : MonoBehaviour
{
    public float speed = 10F;
    public float SteerSpeed = 180;
    public float BodySpeed = 7;
    public int Gap = 2;
    public GameObject BodyPrefab;

     private List<GameObject> BodyParts = new List<GameObject>();
     private List<Vector3> PositionsHistory = new List<Vector3>();

    Rigidbody wormRB;
    public ScoreCounter Score;
    public GameObject deathscreen;
     void Start()
     {
         wormRB = GetComponent<Rigidbody>();
        GrowWorm();
        GrowWorm();
        GrowWorm();
        GrowWorm();
        GrowWorm();

     }

     void FixedUpdate ()
     {
        // disables character movement if the pause screen is active. it works ;)
        if (GameObject.Find("PauseMenu") == true)
        {
            Time.timeScale = 0;
        }
        else if (GameObject.Find("PauseMenu") == false)
        {
            Time.timeScale = 1;
        }
        
        // move based on acceleromter direction
         Vector3 accelerate = Input.acceleration;
         wormRB.AddForce(accelerate.x * speed, 0, accelerate.y * speed * Time.timeScale);


         // Store position history
        PositionsHistory.Insert(0, transform.position);

         // Move body parts
        int index = 0;
        foreach (var body in BodyParts) {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            // Rotate body towards the point along the snakes path
            body.transform.LookAt(point);

            index++;
        }
     }

     private void GrowWorm() {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }


     private void OnTriggerEnter(Collider col)
     {
        if (col.gameObject.tag == "Food")
        {
            Score.food(+5);
            GrowWorm();
        }
        else if (col.tag == "Border")
        {
            EndGame();
        }
     }

     private void EndGame()
     {
        deathscreen.SetActive(true);
        Time.timeScale = 0;
     }

     

 }

 
