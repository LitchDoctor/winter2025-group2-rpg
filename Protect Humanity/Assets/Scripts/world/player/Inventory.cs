using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // create the array to hold items
    public GameObject[] inventory = new GameObject [10];

    public void AddItem(GameObject item)
    {

        bool itemAdded = false;

        // find the first open slot within inventory
        for(int i = 0; i < inventory.Length; i++){
            if(inventory [i] == null) {
                inventory [i] = item;
                Debug.Log (item.name + "was added");
                itemAdded = true;
                break;
            }
        }

        // if inventory is full
        if(itemAdded){
            Debug.Log ("Inventory full - item not added");
        }
    }
}