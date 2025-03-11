using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance; // singleton instance

    public Inventory inventory;

    public Stats baseStats;
    public Stats stats;
    [SerializeField]
    private TextMeshProUGUI attackText, durabilityText, energyText, recoveryText, supportText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep PlayerStats between scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate instances
        }
    }

    void Start(){
        UpdateStats();
    }




    public void UpdateStats(){
        
        stats.Set(baseStats.Add(inventory.getEquipped()));

        attackText.text = stats.attack.ToString();
        durabilityText.text = stats.durability.ToString();
        energyText.text = stats.energy.ToString();
        recoveryText.text = stats.recovery.ToString();
        supportText.text = stats.support.ToString();
    }


}
