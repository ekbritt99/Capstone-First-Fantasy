using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPersistency : MonoBehaviour, IDataPersistence
{
    public int damage;
    public int maxHP;
    public int currentHP;

    public InventoryObject inventory;
    public InventoryObject equipment;

    public Attribute[] attributes;

    public Vector3 spawnPosition;
    public Scenes spawnScene;

    private static PlayerPersistency _instance = null;
    public static PlayerPersistency Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }


    // public void Start()
    // {
    //     // Collect attribute stats 
    //     for(int i = 0; i < attributes.Length; i++)
    //     {
    //         attributes[i].SetParent(this);
    //     }

    //     // This adds on equip event listeners to the equipment slots so that attributes update on equip
    //     for(int i = 0; i < equipment.GetSlots.Length; i++)
    //     {
    //         equipment.GetSlots[i].OnBeforeUpdate += OnRemoveItem;
    //         equipment.GetSlots[i].OnAfterUpdate += OnAddItem;
    //     }

    //     foreach (InventorySlot _slot in equipment.GetSlots)
    //     {
    //         OnAddItem(_slot);
    //     }
    // }

    // public void OnRemoveItem(InventorySlot _slot)
    // {
    //     Debug.Log("OnRemoveItem called");
    //     Debug.Log(_slot.item.ID);
    //     if(_slot.parent == null || _slot.ItemObject == null)
    //         return;
    //     switch(_slot.parent.inventory.type)
    //     {
    //         case InventoryType.Inventory:
    //             break;
    //         case InventoryType.Equipment:
    //             Debug.Log("Removed " + _slot.ItemObject + " on " + _slot.parent.inventory.type);
    //             for(int i = 0; i < _slot.item.buffs.Length; i++)
    //             {
    //                 for(int j = 0; j < attributes.Length; j++)
    //                 {
    //                     if(attributes[j].type == _slot.item.buffs[i].stat)
    //                         attributes[j].value -= _slot.item.buffs[i].value;
    //                 }
    //             }
    //             break;
    //         default:
    //             break;
    //     }
    // }

    // public void OnAddItem(InventorySlot _slot)
    // {
    //     if(_slot.ItemObject == null)
    //         return;
    //     switch(_slot.parent.inventory.type)
    //     {
    //         case InventoryType.Inventory:
    //             break;
    //         case InventoryType.Equipment:
    //             Debug.Log("Equipped " + _slot.ItemObject + " on " + _slot.parent.inventory.type);
    //             Debug.Log("Num Attributes on Item: " + _slot.item.buffs.Length);
    //             for(int i = 0; i < _slot.item.buffs.Length; i++)
    //             {
    //                 for(int j = 0; j < attributes.Length; j++)
    //                 {
    //                     if(attributes[j].type == _slot.item.buffs[i].stat)
    //                         attributes[j].value += _slot.item.buffs[i].value;
    //                 }
    //             }
    //             break;
    //         default:
    //             break;
    //     }
    // }


    

    public void SetHP(int hp)
    {
        if(hp <= maxHP && hp >= 0)
        {
            currentHP = hp;
        }
    }

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if(currentHP <= 0)
            return true;
        else
            return false;
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if(currentHP > maxHP)
            currentHP = maxHP;
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        currentHP = maxHP;
    }

    public void LoadData(GameData data)
    {
        this.currentHP = data.playerHP;
        // this.spawnScene = data.spawnScene;
        // this.spawnPosition = data.spawnPosition;
    }

    public void SaveData(GameData data)
    {
        data.playerHP = this.currentHP;

        // GameObject player = GameObject.Find("Player");
        // if(player != null){
        //     data.spawnPosition = player.gameObject.transform.position;
        // }
        // data.spawnScene = (Scenes) SceneManager.GetActiveScene().buildIndex;

        
    }

    
    // public void AttributeModified(Attribute attribute)
    // {
    //     Debug.Log(string.Concat(attribute));
    // }

    private void OnDisable()
    {
        if(_instance != null && _instance != this)
            return;
        inventory.Save();
        equipment.Save();
        inventory.Clear();
        equipment.Clear();
    }

    public void OnApplicationQuit()
    {
        this.Clear();
    }
}

// [System.Serializable]
// public class Attribute
// {   
//     public PlayerPersistency parent;
//     public Attributes type;
//     public int value;

//     public void SetParent(PlayerPersistency pPersistency)
//     {
//         parent = pPersistency;
//         value = 0;
//     }

//     public void AttributeModified()
//     {
//         parent.AttributeModified(this);
//     }
// }