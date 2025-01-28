using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody2D rb;
    private Vector2 input;


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
        rb.linearVelocity = input*speed;
    }


}
