using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHandler : MonoBehaviour
{

    public GameObject food;

    void Start()
    {
        Vector3 position = new Vector3(Random.Range(-0.85f, 0.85f), 0.075f, Random.Range(-0.85f, 0.85f));
        Instantiate(food, position, Quaternion.identity);
    }
    
}
