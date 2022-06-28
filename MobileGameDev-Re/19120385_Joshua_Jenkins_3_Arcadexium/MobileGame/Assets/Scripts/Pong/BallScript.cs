using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    public Vector3 power;
    public Rigidbody ballRb;
    // Start is called before the first frame update
    void Start()
    {
        ballRb.AddForce(power, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
