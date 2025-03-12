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

    private bool istest = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!istest){
            setInput(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }

    private void FixedUpdate()
    {
        if(canMove){
            rb.linearVelocity = input*speed;
        }else{
            rb.linearVelocity = input*0;
        }
    }

    public void setInput(float x, float y){
        input.x = x;
        input.y = y;

        input.Normalize();
    }

    public void setAsTest(){
        istest = true;
    }

    public void LockMovement(){
        canMove = false;
    }
    public void FreeMovement(){
        canMove = true;
    }

}
