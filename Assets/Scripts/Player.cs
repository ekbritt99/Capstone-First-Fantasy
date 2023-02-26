using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public InventoryObject inventory;
    public InventoryObject equipment;

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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Equals))
        {
            inventory.Save();
            equipment.Save();
        }

        if(Input.GetKeyDown(KeyCode.Backslash))
        {
            inventory.Load();
            equipment.Load();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ItemObject item = inventory.database.GetItem[13];
            inventory.AddItem(item.CreateItem(), 1);

            // item = inventory.database.GetItem[1];
            // inventory.AddItem(item.CreateItem(), 1);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log(inventory.container.Items[0].item.ID);
            inventory.container.Items[0].item.buffs[0].UpgradeStat(5);
        }
    }

}