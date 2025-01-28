/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjectScript = null;

    void update ()
    {
        if(Input.GetButtonDown ("Interact") && currentInterObj){
            currentInterObj.SendMessage ("DoInteraction")
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag ("interObject")){
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.getComponent <InteractionObject> ();
        }
    }

    void OnTriggerExit2D(Collider2D other )
    {
        if(other.CompareTag("interObject")){
            if(other.gameObject == currentInterObj){
                currentInterObj = null;
            }
        }
    }
}
*/