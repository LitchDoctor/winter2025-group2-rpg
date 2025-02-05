using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    //creates an object and sets it to null
    public GameObject currentInterObj = null;

    //function that allows user to use whatever item is being interacted with
    void Update()
    {
        if(Input.GetButtonDown ("Interact") && currentInterObj){
            //Do something with the object
            currentInterObj.sendMessage("DoInteraction");
        }
    }

    //when player comes in contact with an object
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag ("interObject")){
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
        }
    }

    //when players leaves the range of object's collider
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag ("interObject")){
            if(other.gameObject == currentInterObj){
                currentInterObj = null;
            }
        }
    }
}
