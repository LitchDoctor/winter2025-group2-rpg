using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // create the array to hold items
    public GameObject[] inventory = new GameObject [10];
    public GameObject InventoryUI;
    public Button[] itemSlots;

    public void Start () 
    {
        InventoryUI.SetActive(false);
        UpdateInventoryUI();
    }

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
        if(!itemAdded){
            Debug.Log ("Inventory full - item not added");
        }

        UpdateInventoryUI();
    }

    public void RemoveItem(int slotIndex)
    {
        if(inventory[slotIndex] != null){
            Debug.Log("Using " + inventory[slotIndex].name);
            inventory[slotIndex] = null;
        }

        UpdateInventoryUI();
    }

    void UpdateInventoryUI()
    {
        for(int i = 0; i < itemSlots.Length; i++){
            if(inventory[i] != null){
                itemSlots[i].GetComponentInChildren<Text>().text = inventory[i].name;
            }
            else{
                itemSlots[i].GetComponentInChildren<Text>().text = "";
            }
        }
    }

    public void ToggleInventory()
    {
        InventoryUI.SetActive(!InventoryUI.activeSelf);
    }
}