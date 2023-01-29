using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class InventorySystemTests
{

    [Test]
    public void TestAddItemToInventory() {
        var inventory = (InventoryObject)AssetDatabase.LoadAssetAtPath("Assets/Scriptable Objects/Inventory/Player Inventory.asset", typeof(InventoryObject));
        
        var item = new Item();
        item.ID = 1;
        item.Name = "Katana";

        int amt = 15;

        inventory.AddItem(item, amt);

        Assert.AreEqual(item.Name, inventory.container.Items[0].item.Name);
        Assert.AreEqual(amt, inventory.container.Items[0].amount);
    }

    [TearDown]
    public void TearDown() {
        var inventory = (InventoryObject)AssetDatabase.LoadAssetAtPath("Assets/Scriptable Objects/Inventory/Player Inventory.asset", typeof(InventoryObject));
        inventory.container.Items = new InventorySlot[25];
    }

}