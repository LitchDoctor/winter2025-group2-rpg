using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // create the array to hold items
    public GameObject[] inventory = new GameObject [9];
    public GameObject InventoryUI;

    public PlayerStats playerstats;
    public Button equipped;
    private GameObject EquippedItem;
    private GameObject SelectedItem;

    [SerializeField] public Button[] itemSlots;

    public void Start () 
    {
        InventoryUI.SetActive(false);
        // UpdateInventoryUI();
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
                itemSlots[i].GetComponentInChildren<TextMeshProUGUI>().text = inventory[i].name;
                itemSlots[i].GetComponentInChildren<Image>().sprite = inventory[i].GetComponent<SpriteRenderer>().sprite;
            }
            else{
                itemSlots[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }

    public void ToggleInventory()
    {
        InventoryUI.SetActive(!InventoryUI.activeSelf);
    }

    public void SelectItem(int slot){
        SelectedItem = inventory[slot];
    }

    public void equipItem(){
        if (SelectedItem != null){
            EquippedItem = SelectedItem;

            
            equipped.GetComponentInChildren<TextMeshProUGUI>().text = EquippedItem.name;
            equipped.GetComponentInChildren<Image>().sprite = EquippedItem.GetComponent<SpriteRenderer>().sprite;
            // int test = SelectedItem.GetComponent<Stats>().attack;
            
            playerstats.UpdateStats();
        }
    }


    public Stats getEquipped(){
        GameObject g = new GameObject();
        g.AddComponent<Stats>();
        return (EquippedItem != null) ? EquippedItem.GetComponent<Stats>() : g.GetComponent<Stats>();
    }
}