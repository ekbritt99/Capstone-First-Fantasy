using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    // private static Player _instance;
    // public static Player Instance { get { return _instance; } }

    public InventoryObject inventory;
    public InventoryObject equipment;

    public Attribute[] attributes;

    public PlayerCollisions collisions;

    // public PersistentEntityUnit playerUnit;

    // private void Awake()
    // {
    //     if(_instance != null && _instance != this)
    //     {
    //         Destroy(this.gameObject);
    //         return;
    //     }
    //     _instance = this;
    //     DontDestroyOnLoad(this.gameObject);

    // }

    private void Start() 
    {
        Debug.Log("What player sees: " + PersistentEntityUnit.Instance.spawnPosition); 
        if(PersistentEntityUnit.Instance.spawnPosition != null && PersistentEntityUnit.Instance.spawnPosition != Vector3.zero) {
            
            this.gameObject.transform.position = PersistentEntityUnit.Instance.spawnPosition;
        }

        for(int i = 0; i < attributes.Length; i++)
        {
            attributes[i].SetParent(this);
        }

        for(int i = 0; i < equipment.GetSlots.Length; i++)
        {
            equipment.GetSlots[i].OnBeforeUpdate += OnRemoveItem;
            equipment.GetSlots[i].OnAfterUpdate += OnAddItem;
        }
    }


    public void OnRemoveItem(InventorySlot _slot)
    {
        if(_slot.ItemObject == null)
            return;
        switch(_slot.parent.inventory.type)
        {
            case InventoryType.Inventory:
                break;
            case InventoryType.Equipment:
                Debug.Log("Removed " + _slot.ItemObject + " on " + _slot.parent.inventory.type);
                break;
            default:
                break;
        }
    }

    public void OnAddItem(InventorySlot _slot)
    {
        if(_slot.ItemObject == null)
            return;
        switch(_slot.parent.inventory.type)
        {
            case InventoryType.Inventory:
                break;
            case InventoryType.Equipment:
                Debug.Log("Equipped " + _slot.ItemObject + " on " + _slot.parent.inventory.type);
                break;
            default:
                break;
        }
    }


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
            ItemObject item = inventory.database.GetItem[21];
            inventory.AddItem(item.CreateItem(), 1);

            // item = inventory.database.GetItem[1];
            // inventory.AddItem(item.CreateItem(), 1);
        }
        /*
        if (SceneManager.GetActiveScene().name != "Test Village Scene")
        {
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log(inventory.container.Items[0].item.ID);
                inventory.container.Items[0].item.buffs[0].UpgradeStat(5);
            }

        }
        */
    }

    [ContextMenu("EquipItem")]
    public void EquipItem(int fromSlot, int toSlot)
    {
        inventory.MoveItem(inventory.container.Items[fromSlot], equipment.container.Items[toSlot]);
    }

    public void AttributeModified(Attribute attribute)
    {
        Debug.Log(string.Concat(attribute));
    }

}

[System.Serializable]
public class Attribute
{   
    public Player parent;
    public Attributes type;
    public int value;

    public void SetParent(Player player)
    {
        parent = player;
        value = 0;
    }

    public void AttributeModified()
    {
        parent.AttributeModified(this);
    }
}