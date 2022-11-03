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

public class ItemObject : ScriptableObject
{
    public Sprite uiDisplay;
    public GameObject prefab;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
    
}
