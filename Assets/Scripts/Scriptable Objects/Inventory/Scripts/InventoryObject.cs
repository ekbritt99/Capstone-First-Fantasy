using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public string savePath;
    public ItemsDatabaseObject database;
    public Inventory container;


    public bool AddItem(Item _item, int _amt)
    {
        InventorySlot slot = FindItemInInventory(_item);
        if(slot == null || !database.itemObjects[_item.ID].stackable)
        {
            for(int i = 0; i < container.Items.Length; i++)
            {
                if(container.Items[i].item.ID <= -1)
                {
                    SetEmptySlot(_item, _amt);
                    return true;
                }
            }
            return false;
        }
        slot.AddAmount(_amt);
        return true;
    }

    public int EmptySlotCount
    {
        get
        {
            int counter = 0;
            for(int i = 0; i < container.Items.Length; i++)
            {
                if(container.Items[i].item.ID <= -1)
                {
                    counter++;
                }
            }
            return counter;
        }
    }

    public InventorySlot FindItemInInventory(Item item)
    {
        for (int i = 0; i < container.Items.Length; i++)
        {
            if(container.Items[i].item.ID == item.ID)
            {
                return container.Items[i];
            }
        }
        return null;
    }

    public InventorySlot SetEmptySlot(Item _item, int _amount)
    {
        for (int i = 0; i < container.Items.Length; i++)
        {
            if (container.Items[i].item.ID <= -1)
            {
                container.Items[i].UpdateSlot(_item, _amount);
                return container.Items[i];
            }
        }

        // Setup func for when inventory is full
        return null;
    }

    public void MoveItem(InventorySlot item1, InventorySlot item2)
    {
        if(item2.CanPlaceInSlot(item1.ItemObject))
        {
            InventorySlot temp = new InventorySlot(item2.item, item2.amount);
            item2.UpdateSlot(item1.item, item1.amount);
            item1.UpdateSlot(temp.item, temp.amount);
        }
    }

    public void RemoveItem(Item _item)
    {
        for (int i = 0; i < container.Items.Length; i++)
        {
            if (container.Items[i].item == _item)
            {
                container.Items[i].UpdateSlot(null, 0);
            }
        }
    }

    public void OnAfterSerialization()
    {

    }

    [ContextMenu("Save")]
    public void Save()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, container);
        stream.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Inventory newContainer = (Inventory)formatter.Deserialize(stream);
            for (int i = 0; i < container.Items.Length; i++)
            {
                container.Items[i].UpdateSlot(newContainer.Items[i].item, newContainer.Items[i].amount);
            }
            stream.Close();
        }
    }
    [ContextMenu("Clear")]
    public void Clear()
    {
        container.Clear();
    }

}

[System.Serializable]
public class Inventory
{
    public Currency gold;
    public InventorySlot[] Items = new InventorySlot[24];
    public void Clear()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].UpdateSlot(new Item(), 0);
        }
    }

    public bool ContainsItem(ItemObject itemObject)
    {
        return Array.Find(Items, i => i.item.ID == itemObject.data.ID) != null;
    }

    public bool ContainsItem(int id)
    {
        return Items.FirstOrDefault(i => i.item.ID == id) != null;
    }
}

