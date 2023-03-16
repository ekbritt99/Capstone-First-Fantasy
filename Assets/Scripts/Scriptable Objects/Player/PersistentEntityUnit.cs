using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentEntityUnit : MonoBehaviour, IDataPersistence
{
    public int damage;
    public int maxHP;
    public int currentHP;

    public Vector3 spawnPosition;
    public Scenes spawnScene;

    private static PersistentEntityUnit _instance = null;
    public static PersistentEntityUnit Instance { get { return _instance; } }

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
        this.currentHP = data.playerHealth;
        // this.spawnScene = data.spawnScene;
        // this.spawnPosition = data.spawnPosition;
    }

    public void SaveData(GameData data)
    {
        data.playerHealth = this.currentHP;

        // GameObject player = GameObject.Find("Player");
        // if(player != null){
        //     data.spawnPosition = player.gameObject.transform.position;
        // }
        // data.spawnScene = (Scenes) SceneManager.GetActiveScene().buildIndex;

        
    }

    public void OnApplicationQuit()
    {
        this.Clear();
    }
}
