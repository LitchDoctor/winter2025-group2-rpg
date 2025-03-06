using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    // Array to hold items
    public GameObject[] inventory = new GameObject [9];
    public GameObject InventoryUI;


    public PlayerStats playerstats;                        // Reference to player stats
    public Button equipped;                                // Button to display equipped item
    private GameObject EquippedItem;                       // Currently equipped item
    public GameObject ItemInfoPanel;                       // UI panel for displaying item details
    public TextMeshProUGUI itemNameText;                   // Text displaying item name
    public Image itemIcon;                                 // Image displaying item
    public TextMeshProUGUI itemDescriptionText;            // Text displaying item description
    public Button equipButton;                             // Button to equip an item
    private GameObject SelectedItem;                       // Currently selected item                   
    [SerializeField] public Button[] itemSlots;            // Array of item slot buttons




    public void Start ()
    {
        // Hide inventory UI 
        InventoryUI.SetActive(false);
        // UpdateInventoryUI();
    }


    public void AddItem(GameObject item)
    {
        bool itemAdded = false;


        // Find the first open slot within inventory
        for(int i = 0; i < inventory.Length; i++)
        {
            if(inventory [i] == null) 
            {
                inventory [i] = item;
                Debug.Log (item.name + "was added");
                itemAdded = true;
                break;
            }
        }


        // If inventory is full
        if(!itemAdded)
        {
            Debug.Log ("Inventory full - item not added");
        }


        UpdateInventoryUI();
    }

    // Method to remove item from inventory
    public void RemoveItem(int slotIndex)
    {
        if(inventory[slotIndex] != null)
        {
            Debug.Log("Using " + inventory[slotIndex].name);
            inventory[slotIndex] = null;
        }


        UpdateInventoryUI();
    }


    // Method to update the inventory UI display
    void UpdateInventoryUI()
    {
        for(int i = 0; i < itemSlots.Length; i++){
            if(inventory[i] != null){

                // Displays item name and sprites
                Debug.Log($"Updating UI: Slot {i} -> {inventory[i].name}");
                itemSlots[i].GetComponentInChildren<TextMeshProUGUI>().text = inventory[i].name;
                itemSlots[i].GetComponentInChildren<Image>().sprite = inventory[i].GetComponent<SpriteRenderer>().sprite;

                int index = i;  // Prevent closure issue
                itemSlots[i].onClick.RemoveAllListeners();
                itemSlots[i].onClick.AddListener(() => SelectItem(index));
            }
            else{
                // Clear slot if empty 
                itemSlots[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }

    // Method to toggle inventory UI on and off
    public void ToggleInventory()
    {
        bool isActive = !InventoryUI.activeSelf;
        InventoryUI.SetActive(!InventoryUI.activeSelf);

        if(isActive)
        {
            ItemInfoPanel.SetActive(false);
        }
    }

    // Method to select an item from inventory
    public void SelectItem(int slot)
    {
        SelectedItem = inventory[slot];

        if(SelectedItem != null)
        {
            // Display item details in the UI
            itemNameText.text = SelectedItem.name;
            itemIcon.sprite = SelectedItem.GetComponent<SpriteRenderer>().sprite;
            InteractionObject itemScript = SelectedItem.GetComponent<InteractionObject>();

            ItemInfoPanel.SetActive(true);

            // Assign equip button functionality
            equipButton.onClick.RemoveAllListeners();
            equipButton.onClick.AddListener(() => equipItem());
            if (itemScript != null && itemDescriptionText != null)
            {
                // Show item description
                itemDescriptionText.text = itemScript.description; 
            }
            else
            {
                itemDescriptionText.text = "No description available.";
            }
        }
    }
    
    // Method to equip the selected item    
    public void equipItem(){
        if (SelectedItem != null){
            EquippedItem = SelectedItem;

            // Update UI with equipped item details
            equipped.GetComponentInChildren<TextMeshProUGUI>().text = EquippedItem.name;
            equipped.GetComponentInChildren<Image>().sprite = EquippedItem.GetComponent<SpriteRenderer>().sprite;
            // int test = SelectedItem.GetComponent<Stats>().attack;
            
            // Update player stats
            playerstats.UpdateStats();
        }
    }

    // Method to unequip the currently equipped item
    public void UnequipItem(){
        EquippedItem = null;

        // Reset equipped item UI
        equipped.GetComponentInChildren<TextMeshProUGUI>().text = "Equipped";
        equipped.GetComponentInChildren<Image>().sprite = null;

        // Update player stats
        playerstats.UpdateStats();
    }

    // Method to get stats of the currently equipped item
    public Stats getEquipped(){
        GameObject g = new GameObject();
        g.AddComponent<Stats>();
        return (EquippedItem != null) ? EquippedItem.GetComponent<Stats>() : g.GetComponent<Stats>();
    }
}