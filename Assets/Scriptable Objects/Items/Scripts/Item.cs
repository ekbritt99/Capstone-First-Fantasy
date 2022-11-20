using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    public ItemObject item;

    public string Name;
    public int ID;
    public Item()
    {
        Name = "";
        ID = -1;
    }
    
    public Item(ItemObject item)
    {
        Name = item.name;
        ID = item.ID;
        
    }

}
