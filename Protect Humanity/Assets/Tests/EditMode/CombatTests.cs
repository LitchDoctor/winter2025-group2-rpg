using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CombatTests
{
    // A Test behaves as an ordinary method

    [Test]
    public void TakeDamage()
    {
        GameObject obj  = new GameObject();
        Unit unit = obj.AddComponent<Unit>();

        unit.maxHP = 10;
        unit.currentHP = 10;

        unit.TakeDamage(5);

        Assert.AreEqual(5, unit.currentHP);
    }

    [Test]
    public void TakeDamageAndLive()
    {
        GameObject obj  = new GameObject();
        Unit unit = obj.AddComponent<Unit>();

        unit.maxHP = 10;
        unit.currentHP = 10;

        bool live = unit.TakeDamage(5);

        Assert.AreEqual(false, live);
    }
    [Test]
    public void TakeDamageAndDie()
    {
        GameObject obj  = new GameObject();
        Unit unit = obj.AddComponent<Unit>();

        unit.maxHP = 10;
        unit.currentHP = 3;

        bool live = unit.TakeDamage(5);

        Assert.AreEqual(true, live);
    }
    [Test]
    public void HealHealth()
    {
        GameObject obj  = new GameObject();
        Unit unit = obj.AddComponent<Unit>();

        unit.maxHP = 10;
        unit.currentHP = 5;

        unit.Heal(4);

        Assert.AreEqual(9, unit.currentHP);    
    }

}
