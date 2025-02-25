using NUnit.Framework.Interfaces;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int attack = 0, durability = 0, energy = 0, recovery = 0, support = 0;

    public void Initialize(int baseAttack, int baseDurability, int baseEnergy, int baseRecovery, int baseSupport)
    {
        attack = baseAttack;
        durability = baseDurability;
        energy = baseEnergy;
        recovery = baseRecovery;
        support = baseSupport;
    }

    public void Set(int newAttack, int newDurability, int newEnergy, int newRecovery, int newSupport)
    {
        attack = newAttack;
        durability = newDurability;
        energy = newEnergy;
        recovery = newRecovery;
        support = newSupport;
    }

    public void Set(Stats s1)
    {
        attack = s1.attack;
        durability = s1.durability;
        energy = s1.energy;
        recovery = s1.recovery;
        support = s1.support;
    }

    public Stats Add(Stats s1)
    {
        
        GameObject g = new GameObject();
        g.AddComponent<Stats>();
        Stats result = g.GetComponent<Stats>();
        result.Initialize(attack + s1.attack, durability + s1.durability, energy + s1.energy, recovery + s1.recovery, support + s1.support);
        return result;
    }
}
