using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 input;

    private bool canMove = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();
    }

    private void FixedUpdate()
    {
        if(canMove){
            rb.linearVelocity = input*speed;
        }else{
            rb.linearVelocity = input*0;
        }
    }

    public void LockMovement(){
        canMove = false;
    }
    public void FreeMovement(){
        canMove = true;
    }

}
