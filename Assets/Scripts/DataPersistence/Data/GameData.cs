using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int playerHP;
    public int playerMaxHP;
    public int playerDamage;
    public int playerDefense;
    public int playerIntellect;
    public int playerAgility;
    public int playerStrength;

    public Vector3 spawnPosition;
    public Scenes spawnScene;
    public InventoryData inventory;
    // public int playerMoney;

    public GameData()
    {
        this.playerHP = 100;
        this.playerMaxHP = 100;
        this.playerDamage = 15;
        this.playerDefense = 0;
        this.playerIntellect = 0;
        this.playerAgility = 0;
        this.playerStrength = 0;
        this.spawnPosition = Vector3.zero;
        this.spawnScene = Scenes.HOUSE;
        inventory = new InventoryData();
    }

}
