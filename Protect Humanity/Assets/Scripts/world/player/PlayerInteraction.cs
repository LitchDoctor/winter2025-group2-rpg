using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject currentInterObj = null;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag ("interObject")){
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag ("interObject")){
            if(other.gameObject == currentInterObj){
                currentInterObj = null;
            }
        }
    }
}
