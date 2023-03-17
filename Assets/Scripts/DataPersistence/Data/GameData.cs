using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int playerHP;
    public int playerMaxHP;
    public int playerDamage;
    public Vector3 spawnPosition;
    public Scenes spawnScene;
    public InventoryData inventory;
    // public int playerMoney;

    public GameData()
    {
        this.playerHP = 100;
        this.playerMaxHP = 100;
        this.playerDamage = 15;
        this.spawnPosition = Vector3.zero;
        this.spawnScene = Scenes.HOUSE;
        inventory = new InventoryData();
    }

}
