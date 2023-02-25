using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour, IDataPersistence
{
    public InventoryObject playerInventory;
    public InventoryObject playerEquipment;

    public GameObject dataManagerObj;
    public DataPersistenceManager dataManager;

    public GameObject notEnoughFunds;
    public GameObject purchaseSuccessful;

    public int currPlayerMoney;
    public TMP_Text lblCurrentMoneyAmount;

    // Start is called before the first frame update
    void Start()
    {
        dataManager = dataManagerObj.GetComponent<DataPersistenceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        lblCurrentMoneyAmount.text = currPlayerMoney.ToString();
    }

    public void purchaseKatana()
    {
        if (currPlayerMoney >= 5)
        {
            currPlayerMoney -= 5;
            ItemObject item = playerInventory.database.GetItem[1];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }
        
    }

    public void purchaseMace()
    {
        if (currPlayerMoney >= 5)
        {
            currPlayerMoney -= 5;
            ItemObject item = playerInventory.database.GetItem[3];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }

    public void purchaseScimitar()
    {
        if (currPlayerMoney >= 5)
        {
            currPlayerMoney -= 5;
            ItemObject item = playerInventory.database.GetItem[5];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }

    public void purchaseRomanSword()
    {
        if (currPlayerMoney >= 5)
        {
            currPlayerMoney -= 5;
            ItemObject item = playerInventory.database.GetItem[4];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }




    public void purchasePlatinumArmor()
    {
        if (currPlayerMoney >= 11)
        {
            currPlayerMoney -= 11;
            ItemObject item = playerInventory.database.GetItem[9];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseBasicArmor()
    {
        if (currPlayerMoney >= 5)
        {
            currPlayerMoney -= 5;
            ItemObject item = playerInventory.database.GetItem[6];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseBronzeArmor()
    {
        if (currPlayerMoney >= 7)
        {
            currPlayerMoney -= 7;
            ItemObject item = playerInventory.database.GetItem[7];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseIronArmor()
    {
        if (currPlayerMoney >= 9)
        {
            currPlayerMoney -= 9;
            ItemObject item = playerInventory.database.GetItem[8];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }


    public void purchaseIronBoots()
    {
        if (currPlayerMoney >= 9)
        {
            currPlayerMoney -= 9;
            ItemObject item = playerInventory.database.GetItem[12];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseLeatherBoots()
    {
        if (currPlayerMoney >= 5)
        {
            currPlayerMoney -= 5;
            ItemObject item = playerInventory.database.GetItem[10];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseStuddedBoots()
    {
        if (currPlayerMoney >= 7)
        {
            currPlayerMoney -= 7;
            ItemObject item = playerInventory.database.GetItem[11];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }





    public void purchaseWoodenShield()
    {
        if (currPlayerMoney >= 5)
        {
            currPlayerMoney -= 5;
            ItemObject item = playerInventory.database.GetItem[13];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseKiteShield()
    {
        if (currPlayerMoney >= 7)
        {
            currPlayerMoney -= 7;
            ItemObject item = playerInventory.database.GetItem[14];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseTowerShield()
    {
        if (currPlayerMoney >= 9)
        {
            currPlayerMoney -= 9;
            ItemObject item = playerInventory.database.GetItem[15];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }





    public void purchaseLeatherPants()
    {
        if (currPlayerMoney >= 5)
        {
            currPlayerMoney -= 5;
            ItemObject item = playerInventory.database.GetItem[16];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseStuddedPants()
    {
        if (currPlayerMoney >= 7)
        {
            currPlayerMoney -= 7;
            ItemObject item = playerInventory.database.GetItem[17];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseChainmailPants()
    {
        if (currPlayerMoney >= 9)
        {
            currPlayerMoney -= 9;
            ItemObject item = playerInventory.database.GetItem[18];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }

    public void purchaseStuddedHelmet()
    {
        if (currPlayerMoney >= 5)
        {
            currPlayerMoney -= 5;
            ItemObject item = playerInventory.database.GetItem[19];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }

    public void purchaseHornedHelmet()
    {
        if (currPlayerMoney >= 7)
        {
            currPlayerMoney -= 7;
            ItemObject item = playerInventory.database.GetItem[20];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseKnightHelmet()
    {
        if (currPlayerMoney >= 9)
        {
            currPlayerMoney -= 9;
            ItemObject item = playerInventory.database.GetItem[21];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }

    

    public void purchaseShieldBuff()
    {
        playerEquipment.container.Items[5].item.buffs[0] = new ItemBuff(10, 20);
    }
    public void purchaseBootsBuff()
    {
        playerEquipment.container.Items[4].item.buffs[0] = new ItemBuff(10, 20);
    }
    public void purchaseChestBuff()
    {
        playerEquipment.container.Items[4].item.buffs[0] = new ItemBuff(10, 20);
    }
    public void purchasLegsBuff()
    {
        playerEquipment.container.Items[4].item.buffs[0] = new ItemBuff(10, 20);
    }
    public void purchasHelmetBuff()
    {
        playerEquipment.container.Items[4].item.buffs[0] = new ItemBuff(10, 20);
    }


    public void LoadData(GameData data)
    {
        this.currPlayerMoney = data.playerMoney;
    }

    public void SaveData(GameData data)
    {
        data.playerMoney = this.currPlayerMoney;
    }
}
