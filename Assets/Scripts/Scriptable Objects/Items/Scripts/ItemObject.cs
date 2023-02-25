using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum ItemType
{
    Helmet,
    Chest,
    Legs,
    Boots,
    Weapon,
    Shield,
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
    public bool stackable = false;
    public Item data = new Item();
    
    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}
