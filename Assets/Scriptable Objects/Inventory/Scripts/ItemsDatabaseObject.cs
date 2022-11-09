using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// TODO : This currently isn't implemented, need to add a database object thru unity and put all items in said database.

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/Database")]
public class ItemsDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] itemObjects;

    public Dictionary<ItemObject, int> GetID;
    public Dictionary<ItemObject, int> GetItem;

    public void OnBeforeSerialize()
    {
        //GetItem = new();

    }

    public void OnAfterDeserialize()
    {
        GetItem = new();
        for (int i = 0; i < itemObjects.Length; i++)
        {
            itemObjects[i].id = i;
            GetItem.Add(itemObjects[i], i);
        }
    }

    
}
