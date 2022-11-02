using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : ScriptableObject
{
    public string savePath;
    private ItemsDatabaseObject database;
    public List<ItemObject> container;

    public void OnEnable()
    {
        
    }

    public void AddItem(ItemObject item, int amt)
    {

    }

    public void OnAfterSerialization()
    {

    }

    public void Save()
    {

    }

    public void Load()
    {

    }
}
