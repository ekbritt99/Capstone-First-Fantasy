using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// TODO : This currently isn't implemented, need to add a database object thru unity and put all items in said database.

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/Database")]
public class ItemsDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] itemObjects;

    public Dictionary<int, ItemObject> GetItem = new();

    public void OnBeforeSerialize()
    {
        GetItem = new();
    }

    public void OnAfterDeserialize()
    { 
        for (int i = 0; i < itemObjects.Length; i++)
        {
            itemObjects[i].ID = i;
            GetItem.Add(i, itemObjects[i]);
        }
    }

    
}
