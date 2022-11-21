using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum ItemType
{
    Armor,
    Weapon,
    Food,
    Default
}

public abstract class ItemObject : ScriptableObject
{
    public int ID;
    public Sprite uiDisplay;
    public GameObject prefab;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
    
    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}
