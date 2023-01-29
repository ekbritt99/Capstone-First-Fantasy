using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class InventorySystemTests
{

    [Test]
    public void TestAddItemToInventory()
    {
        var inventory = (InventoryObject)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Scriptable Objects/Inventory/Player Inventory.asset", typeof(InventoryObject));
        var database = (ItemsDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Items/ItemsDatabaseObject.asset", typeof(ItemsDatabaseObject));

        var random = Random.Range(0, database.itemObjects.Length);

        Debug.Log(random);

        var item = database.GetItem[random];
        Debug.Log(item.ID);

        int amt = 1;
        Item item1 = item.CreateItem();

        inventory.AddItem(item1, amt);

        Assert.AreEqual(item1.Name, inventory.container.Items[0].item.Name);
        Assert.AreEqual(amt, inventory.container.Items[0].amount);
    }
    

    [TearDown]
    public void TearDown() 
    {
        var inventory = (InventoryObject)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Scriptable Objects/Inventory/Player Inventory.asset", typeof(InventoryObject));
        inventory.container.Items = new InventorySlot[25];
    }

}