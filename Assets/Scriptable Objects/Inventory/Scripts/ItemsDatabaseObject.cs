using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDatabaseObject : ScriptableObject
{
    public ItemObject[] itemObjects;

    public Dictionary<ItemObject, int> GetID;
    public Dictionary<int, ItemObject> GetItem;

    public void OnAfterSerialize()
    {

    }
}
