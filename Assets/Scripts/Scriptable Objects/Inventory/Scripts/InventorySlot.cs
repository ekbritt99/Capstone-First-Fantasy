using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventorySlot
{
    public ItemType[] AllowedItems = new ItemType[0];

    [System.NonSerialized]
    public InventoryInterface parent;
    [System.NonSerialized]
    public SlotUpdated OnBeforeUpdate;
    [System.NonSerialized]
    public SlotUpdated OnAfterUpdate;
    public Item item;
    public int amount;
    public ItemObject ItemObject
    {
        get
        {
            if(item.ID >= 0)
                return parent.inventory.database.GetItem[item.ID];
            return null;
        }
    }

    public InventorySlot()
    {
        item = new Item();
        amount = 0;
    }

    public InventorySlot(Item _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int val)
    {
        amount += val;
    }

    public void UpdateSlot(Item _item, int _amount)
    {
        if(OnBeforeUpdate != null)
        {
            OnBeforeUpdate.Invoke(this);
        }
        item = _item;
        amount = _amount;
        if(OnAfterUpdate != null)
        {
            OnAfterUpdate.Invoke(this);
        }
    }

    public void RemoveItem()
    {
        item = new Item();
        amount = 0;
    }

    public bool CanPlaceInSlot(ItemObject _item)
    {
        if(AllowedItems.Length <=0 || _item == null)
        {
            return true;
        }
        for (int i = 0; i < AllowedItems.Length; i++)
        {
            if(_item.type == AllowedItems[i])
                return true;
        }
        return false; 
    }
}

public delegate void SlotUpdated(InventorySlot _slot);
