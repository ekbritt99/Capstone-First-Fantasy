using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]

public class InventoryObject : ScriptableObject
{
    public string savePath;
    public ItemsDatabaseObject database;
    public List<InventorySlot> container = new List<InventorySlot>();

    public void OnEnable()
    {
        
    }

    public void AddItem(ItemObject _item, int _amt)
    {
        bool hasItem = false;
        for(int i = 0; i < container.Count; i++)
        {
            if(container[i].item == _item)
            {
                container[i].AddAmount(_amt);
                hasItem = true;
                break;
            }
        }

        if (!hasItem)
        {
            container.Add(new InventorySlot(_item, _amt));
        }
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