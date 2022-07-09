using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScripts : MonoBehaviour
{
    public float moveSpeed = 10f;


    private Rigidbody rb;
    private bool MoveLeft;
    private bool moveRight;
    private float horizontalMove;

    void Start()
    {
        rb = GetComponent<Rigidbody>();


        MoveLeft = false;
        moveRight = false;
    }
    
    void Update()
    {
        playerMovement();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontalMove,rb.velocity.y,0);
    }
    public void up()
    {
        MoveLeft = true;


    }
    public void upfalse()
    {
        MoveLeft = false;
    }

    public void down()
    {
        moveRight = true;
    
    }

    public void downfalse()
    {
        moveRight = false;
    }

    private void playerMovement()
    {
        if (MoveLeft)
        {
            horizontalMove = moveSpeed;
        }
        else if(moveRight)
        {
            horizontalMove = -moveSpeed;
        }
        else
        {
            horizontalMove = 0;
        }
    }



}
