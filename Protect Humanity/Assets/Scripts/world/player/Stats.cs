using NUnit.Framework.Interfaces;
using UnityEngine;


public class Stats : MonoBehaviour
    {
    public int level = 0, maxHp = 0, durability = 0, energy = 0, support = 0;


    public void Initialize(int baselevel, int baseMaxHp, int baseDurability, int baseEnergy, int baseSupport)
    {
        level = baselevel;
        durability = baseDurability;
        energy = baseEnergy;
        maxHp = baseMaxHp;
        support = baseSupport;
    }


    public void Set(int newLevel, int newMaxHp, int newDurability, int newEnergy, int newSupport)
    {
        level = newLevel;
        durability = newDurability;
        energy = newEnergy;
        maxHp = newMaxHp;
        support = newSupport;
    }


    public void Set(Stats s1)
    {
        level = s1.level;
        durability = s1.durability;
        energy = s1.energy;
        maxHp = s1.maxHp;
        support = s1.support;
    }


    public Stats Add(Stats s1)
    {
        GameObject g = new GameObject();
        g.AddComponent<Stats>();
        Stats result = g.GetComponent<Stats>();
        result.Initialize(level + s1.level, maxHp + s1.maxHp, durability + s1.durability, energy + s1.energy, support + s1.support);
        return result;
    }
}
