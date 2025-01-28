using System;
using TMPro;
using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    public int attack, durability, energy, recovery, support;

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
