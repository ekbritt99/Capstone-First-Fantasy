using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int playerHealth;
    public Vector3 playerPosition;
    public InventoryData inventory;
    public int playerMoney;

    public GameData()
    {
        this.playerHealth = 100;
        this.playerPosition = new Vector3(-2.789f,-1.228f,1.565f);
        this.playerMoney = 25;
        inventory = new InventoryData();
    }

}
