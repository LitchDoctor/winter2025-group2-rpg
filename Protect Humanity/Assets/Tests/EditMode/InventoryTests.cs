using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class InventoryTests
{

    [UnityTest]
    public IEnumerator InventoryPickup()
    {
        GameObject Item = new GameObject();
        InteractionObject inter = Item.AddComponent<InteractionObject>();
        inter.inventory = true;
        inter.DoInteraction();

        yield return null;

        Assert.AreEqual(false, Item.activeInHierarchy);
    }

    [UnityTest]
    public IEnumerator NonInventoryPickup()
    {
        GameObject Item = new GameObject();
        InteractionObject inter = Item.AddComponent<InteractionObject>();
        inter.inventory = false;

        inter.DoInteraction();

        yield return null;
        
        Assert.AreEqual(true, Item.activeInHierarchy);
    }
}
