using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InteractionObject : MonoBehaviour
{
    public bool inventory; //if true, object can be stored in inventory
    [TextArea]
    public string description;
    private Rigidbody2D rb;


    void Start()
        {
        rb = GetComponent<Rigidbody2D>();
        }
    public void DoInteraction()
    {
        if(inventory){
        //Picked up and put in inventory
        gameObject.SetActive(false);
        }
        else {
        Debug.Log("Interacted with " + gameObject.name);
        }
    }
}
