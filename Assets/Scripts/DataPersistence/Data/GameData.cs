using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int playerHealth;
    public Vector3 spawnPosition;
    public Scenes spawnScene;
    public InventoryData inventory;
    // public int playerMoney;

    public GameData()
    {
        this.playerHealth = 100;
        this.spawnPosition = Vector3.zero;
        this.spawnScene = Scenes.HOUSE;
        inventory = new InventoryData();
    }

}
