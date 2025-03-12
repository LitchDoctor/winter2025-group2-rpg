using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class FollowerMovement : MonoBehaviour
{
    public GameObject player;
    private Queue<Vector3> playerHistory;

    private Vector3 oldPlayerPos;
    
    public int followDistance = 10;


    void Awake()
    {
        Debug.Log("Awake called.");
        FindNewPlayer();
        playerHistory = new Queue<Vector3>(); //create a blank list
        oldPlayerPos = player.transform.position;
    }

    void FindNewPlayer()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player"); // Assumes player has the "Player" tag

            Debug.Log("new player set");

            if (player != null)
            {
                oldPlayerPos = player.transform.position;
            }
        }
        else
        {
            Debug.Log("player not null");
        }
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            if (player.transform.position != oldPlayerPos)
            {
                playerHistory.Enqueue(player.transform.position);
            }
            if (Vector3.Distance(player.transform.position, transform.position) > followDistance && playerHistory.Count != 0)
            {
                transform.position = playerHistory.Dequeue();
            }
            oldPlayerPos = player.transform.position;
        }
        else
        {
            FindNewPlayer();
        }
    }

}
