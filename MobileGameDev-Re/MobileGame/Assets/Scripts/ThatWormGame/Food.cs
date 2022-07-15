using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public GameObject food;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Worm")
        {
            CreateFood();
        }
        
    }

    private void CreateFood()
    {
        
        Vector3 position = new Vector3(Random.Range(-0.85f, 0.85f), 0.075f, Random.Range(-0.85f, 0.85f));
        Instantiate(food, position, Quaternion.identity);
        Destroy(gameObject);
    }
}
