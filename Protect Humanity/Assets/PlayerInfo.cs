using UnityEngine;

public class Player : MonoBehaviour
{
    public string unitName;
    public int unitLevel;
    
    public int damage;
    public int maxHP;
    public int currentHP;
    public int durability;
    public int energy;


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
            unitLevel = 1;
            //maxHP = PlayerStats.Instance.stats.maxHP; use base value
            maxHP = 30;
            currentHP = maxHP;  // Start with full health
            damage = PlayerStats.Instance.stats.attack;
            durability = PlayerStats.Instance.stats.durability;
            energy = PlayerStats.Instance.stats.energy;

            Debug.Log($"Player stats loaded: HP {currentHP}/{maxHP}, Damage: {damage}, Durability {durability}, Energy {energy}");
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
