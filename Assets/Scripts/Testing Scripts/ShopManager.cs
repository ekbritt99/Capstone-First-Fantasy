using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    private PlayerPersistency playerPersistency;

    public InventoryObject playerInventory;

    // public GameObject dataManagerObj;
    public DataPersistenceManager dataManager;

    public GameObject notEnoughFunds;
    public GameObject purchaseSuccessful;

    public int currPlayerMoney;
    public TextMeshProUGUI lblCurrentMoneyAmount;

    public GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        playerPersistency = GameObject.Find("PlayerPersistency").GetComponent<PlayerPersistency>();
        // dataManager = dataManagerObj.GetComponent<DataPersistenceManager>();
        //get current player money here

        // lblCurrentMoneyAmount.text = "Test";
    }

    // Update is called once per frame
    void Update()
    {
        // lblCurrentMoneyAmount.text = playerInventory.money.getCurrency().ToString();
        // lblCurrentMoneyAmount.text = "Testing";
    }

    public void purchaseKatana()
    {
        if (playerPersistency.money.canAfford(5))
        {
            playerPersistency.money.removeCurrency(5);
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
        if (playerPersistency.money.canAfford(5))
        {
            playerPersistency.money.removeCurrency(5);
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
        if (playerPersistency.money.canAfford(5))
        {
            playerPersistency.money.removeCurrency(5);
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
        if (playerPersistency.money.canAfford(5))
        {
            playerPersistency.money.removeCurrency(5);
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
        if (playerPersistency.money.canAfford(11))
        {
            playerPersistency.money.removeCurrency(11);
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
        if (playerPersistency.money.canAfford(5))
        {
            playerPersistency.money.removeCurrency(5);
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
        if (playerPersistency.money.canAfford(7))
        {
            playerPersistency.money.removeCurrency(7);
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
        if (playerPersistency.money.canAfford(9))
        {
            playerPersistency.money.removeCurrency(9);
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
        if (playerPersistency.money.canAfford(9))
        {
            playerPersistency.money.removeCurrency(9);
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
        if (playerPersistency.money.canAfford(5))
        {
            playerPersistency.money.removeCurrency(5);
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
        if (playerPersistency.money.canAfford(7))
        {
            playerPersistency.money.removeCurrency(7);
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
        if (playerPersistency.money.canAfford(5))
        {
            playerPersistency.money.removeCurrency(5);
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
        if (playerPersistency.money.canAfford(7))
        {
            playerPersistency.money.removeCurrency(7);
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
        if (playerPersistency.money.canAfford(9))
        {
            playerPersistency.money.removeCurrency(9);
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
        if (playerPersistency.money.canAfford(5))
        {
            playerPersistency.money.removeCurrency(5);
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
        if (playerPersistency.money.canAfford(7))
        {
            playerPersistency.money.removeCurrency(7);
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
        if (playerPersistency.money.canAfford(9))
        {
            playerPersistency.money.removeCurrency(9);
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
        if (playerPersistency.money.canAfford(5))
        {
            playerPersistency.money.removeCurrency(5);
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
        if (playerPersistency.money.canAfford(7))
        {
            playerPersistency.money.removeCurrency(7);
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
        if (playerPersistency.money.canAfford(9))
        {
            playerPersistency.money.removeCurrency(9);
            ItemObject item = playerInventory.database.GetItem[21];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }

    public void purchaseRedPotion()
    {
        if (playerPersistency.money.canAfford(5))
        {
            playerPersistency.money.removeCurrency(9);
            ItemObject item = playerInventory.database.GetItem[0];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }

    public void purchaseStrangeBrew()
    {
        if (playerPersistency.money.canAfford(7))
        {
            playerPersistency.money.removeCurrency(9);
            ItemObject item = playerInventory.database.GetItem[2];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }

    public void purchaseGoldenElixir()
    {
        if (playerPersistency.money.canAfford(9))
        {
            playerPersistency.money.removeCurrency(9);
            ItemObject item = playerInventory.database.GetItem[22];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }


    public void resetMoney()
    {
        playerPersistency.money.addCurrency(25);
    }



}
