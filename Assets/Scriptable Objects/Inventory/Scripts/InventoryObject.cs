using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]

public class InventoryObject : ScriptableObject
{
    public string savePath;
    public ItemsDatabaseObject database;
    public InventorySlot[] container = new InventorySlot[24];

    public void OnEnable()
    {
        
    }

    public void AddItem(ItemObject _item, int _amt)
    {
        for(int i = 0; i < container.Length; i++)
        {
            if(container[i].item == _item)
            {
                container[i].AddAmount(_amt);
                return;
            }
        }

        SetEmptySlot(_item, _amt);
    }

    public InventorySlot SetEmptySlot(ItemObject _item, int _amount)
    {
        for (int i = 0; i < container.Length; i++)
        {
            if (container[i].ID <= -1)
            {
                container[i].UpdateSlot(_item.ID, _item, _amount);
                return container[i];
            }
        }

        return null;
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