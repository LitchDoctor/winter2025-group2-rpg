using UnityEngine;

public class Player : MonoBehaviour
{
    public string unitName;
    public int unitLevel;
    
    public int maxHP;
    public int currentHP;
    public int durability;
    public int energy;
    public int support;


    private void Start()
    {
        LoadStatsFromPlayerStats();
    }

    public void InitializeStats(){
        LoadStatsFromPlayerStats();
    }

    private void LoadStatsFromPlayerStats()
    {
        if (PlayerStats.Instance != null) 
        {
            // Load stats from PlayerStats
            //unitLevel = PlayerStats.Instance.stats.level; use base value
            //maxHP = PlayerStats.Instance.stats.maxHP; use base value
            maxHP = PlayerStats.Instance.stats.maxHp;
            currentHP = maxHP;  // Start with full health
            unitLevel = PlayerStats.Instance.stats.level;
            durability = PlayerStats.Instance.stats.durability;
            energy = PlayerStats.Instance.stats.energy;
            support = PlayerStats.Instance.stats.support;

            Debug.Log($"Player stats loaded: HP {currentHP}/{maxHP}, Level: {unitLevel}, Durability {durability}, Energy {energy}, Support {support}");
        }
        else
        {
            Debug.LogWarning("PlayerStats instance not found! Default values will be used.");
        }
    }

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;
        return currentHP <= 0;
    }

    public void Heal(int amount)
    {
        currentHP = Mathf.Min(currentHP + amount, maxHP);
    }
}
