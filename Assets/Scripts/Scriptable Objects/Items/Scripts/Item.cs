using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string Name;
    public int ID;
    public ItemBuff[] buffs;

    public Item()
    {
        Name = "";
        ID = -1;
    }
    
    public Item(ItemObject item)
    {
        Name = item.name;
        ID = item.ID;
        buffs = new ItemBuff[item.data.buffs.Length];
        for(int i = 0; i < buffs.Length; i++) 
        {
            buffs[i] = new ItemBuff(item.data.buffs[i].Min, item.data.buffs [i].Max);
            buffs[i].stat = item.data.buffs[i].stat;
        }
        
    }

    public bool healPlayer()
    {
        GameObject playerObj = GameObject.Find("PlayerPersistency");
        PlayerPersistency playerStats = playerObj.GetComponent<PlayerPersistency>();
        if(playerStats.currentHP < 100)
        {
            if (this.ID == 0)
            {
                playerStats.Heal(15);
            }
            if (this.ID == 2)
            {
                playerStats.Heal(25);
            }
            if (this.ID == 22)
            {
                playerStats.Heal(35);
            }
            return true;
        }
        else
        {
            return false;
        }
        
    }

}
