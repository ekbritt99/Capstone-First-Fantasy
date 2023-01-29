using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Armor Object", menuName = "Inventory System/Items/Armor")]

public class HelmetObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Helmet;
    }

}
