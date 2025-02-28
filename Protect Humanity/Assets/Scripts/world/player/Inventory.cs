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
    public GameObject ItemInfoPanel;
    public TextMeshProUGUI itemNameText;
    public Image itemIcon;
    public TextMeshProUGUI itemDescriptionText;
    public Button equipButton;

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
        bool isActive = !InventoryUI.activeSelf;
        InventoryUI.SetActive(!InventoryUI.activeSelf);

        if(isActive)
        {
            ItemInfoPanel.SetActive(false);
        }
    }

    public void SelectItem(int slot)
    {
        SelectedItem = inventory[slot];

        if(SelectedItem != null)
        {
            itemNameText.text = SelectedItem.name;
            itemIcon.sprite = SelectedItem.GetComponent<SpriteRenderer>().sprite;
            InteractionObject itemScript = SelectedItem.GetComponent<InteractionObject>();

            ItemInfoPanel.SetActive(true);

            equipButton.onClick.RemoveAllListeners();
            equipButton.onClick.AddListener(() => equipItem());
            if (itemScript != null && descriptionText != null)
            {
                itemDescriptionText.text = itemScript.description; // Show item description
            }
            else
            {
                itemDescriptionText.text = "No description available.";
            }
        }
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