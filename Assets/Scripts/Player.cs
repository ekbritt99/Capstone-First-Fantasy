using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public InventoryObject inventory;

    // public InventoryObject inventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // var item = other.GetComponent<Item>();
        // if (item)
        // {
        //     inventory.AddItem(item, 1);
        //     Destroy(other.gameObject);
        // }
    }

}