using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text levelText;
    public Slider hpSlider;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl " + unit.unitLevel;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    public void SetHUDPlayer(Player unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl " + unit.unitLevel;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;

        Debug.Log($"Set HUD: {unit.unitName} - Lvl {unit.unitLevel} - HP: {unit.currentHP}/{unit.maxHP}");
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    } 
}
