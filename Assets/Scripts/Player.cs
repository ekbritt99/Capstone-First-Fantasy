using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public MouseItem mouseItem = new MouseItem();
    public InventoryObject inventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // var item = other.GetComponent<Item>();
        // if (item)
        // {
        //     inventory.AddItem(item, 1);
        //     Destroy(other.gameObject);
        // }
    }

    private void OnApplicationQuit()
    {
        inventory.container.Items = new InventorySlot[25];
    }
}

public class MouseItem
{
    public GameObject obj;
    public InventorySlot item;
    public InventorySlot hoverItem;
    public GameObject hoverObj;
}
