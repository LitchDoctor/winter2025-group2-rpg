using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class FollowerMovement : MonoBehaviour
{
    public GameObject player;
    private Queue<Vector3> playerHistory;

    private Vector3 oldPlayerPos;
    
    public int followDistance = 10;


    void Awake()
    {
        playerHistory = new Queue<Vector3>(); //create a blank list
        oldPlayerPos = player.transform.position;
    }

    void FixedUpdate()
    {
        if(player.transform.position != oldPlayerPos){
            playerHistory.Enqueue(player.transform.position);
        }
        if (Vector3.Distance(player.transform.position, transform.position) > followDistance){
            transform.position = playerHistory.Dequeue();
        }
        oldPlayerPos = player.transform.position;
    }



}
