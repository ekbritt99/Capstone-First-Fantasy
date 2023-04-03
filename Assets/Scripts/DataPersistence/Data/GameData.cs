using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int playerHP;
    public int playerMaxHP;
    public int money;
    public int playerDamage;
    public int playerDefense;
    public int playerIntellect;
    public int playerAgility;
    public int playerStrength;

    public int[] openedChests;

    // public int deathCount;

    // public Vector3 spawnPosition;
    // public Scenes spawnScene;
    // public InventoryData inventory;
    // public int playerMoney;

    public GameData()
    {
        this.playerHP = 30;
        this.playerMaxHP = 30;
        this.money = 30;
        this.playerDamage = 5;
        this.playerDefense = 0;
        this.playerIntellect = 0;
        this.playerAgility = 0;
        this.playerStrength = 0;
        this.openedChests = new int[14];
        // this.deathCount = 0;
        // this.spawnPosition = Vector3.zero;
        // this.spawnScene = Scenes.HOUSE;
        // inventory = new InventoryData();
    }

    public int GetHealth()
    {
        return playerHP;
    }

    public int GetMaxHealth()
    {
        return playerMaxHP;
    }

    // public int GetDeathCount()
    // {
    //     return deathCount;
    // }

}
