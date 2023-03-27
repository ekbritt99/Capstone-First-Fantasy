using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This object is for player stats that should not be destroyed on new scene loads
// It is essentially double dipping on the job of DataPersistencyManager so this will probably change later
public class PlayerPersistency : MonoBehaviour, IDataPersistence
{
    // Player Stats
    public int damage;
    public int maxHP;
    public int currentHP;

    public Attribute[] attributes;

    public InventoryObject inventory;
    public InventoryObject equipment;


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