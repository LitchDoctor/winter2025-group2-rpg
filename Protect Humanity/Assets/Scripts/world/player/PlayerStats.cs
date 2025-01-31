using System;
using TMPro;
using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    public int attack = 5, durability = 3, energy = 2, recovery = 1, support = 15;

    [SerializeField]
    private TMP_Text attackText, durabilityText, energyText, recoveryText, supportText;
    void Start(){
        UpdateStats();
    }


    public void UpdateStats(){
        attackText.text = attack.ToString();
        durabilityText.text = durability.ToString();
        energyText.text = energy.ToString();
        recoveryText.text = recovery.ToString();
        supportText.text = support.ToString();
    }

}
