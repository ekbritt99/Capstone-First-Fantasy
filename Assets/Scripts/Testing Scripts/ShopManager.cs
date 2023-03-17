using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public InventoryObject playerInventory;
    public InventoryObject playerEquipment;

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
        // dataManager = dataManagerObj.GetComponent<DataPersistenceManager>();
        //get current player money here

        // lblCurrentMoneyAmount.text = "Test";
    }

    // Update is called once per frame
    void Update()
    {
        // lblCurrentMoneyAmount.text = playerInventory.container.gold.getCurrency().ToString();
        // lblCurrentMoneyAmount.text = "Testing";
    }

    public void purchaseKatana()
    {
        if (playerInventory.container.gold.canAfford(5))
        {
            playerInventory.container.gold.removeCurrency(5);
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
        if (playerInventory.container.gold.canAfford(5))
        {
            playerInventory.container.gold.removeCurrency(5);
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
        if (playerInventory.container.gold.canAfford(5))
        {
            playerInventory.container.gold.removeCurrency(5);
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
        if (playerInventory.container.gold.canAfford(5))
        {
            playerInventory.container.gold.removeCurrency(5);
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
        if (playerInventory.container.gold.canAfford(11))
        {
            playerInventory.container.gold.removeCurrency(11);
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
        if (playerInventory.container.gold.canAfford(5))
        {
            playerInventory.container.gold.removeCurrency(5);
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
        if (playerInventory.container.gold.canAfford(7))
        {
            playerInventory.container.gold.removeCurrency(7);
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
        if (playerInventory.container.gold.canAfford(9))
        {
            playerInventory.container.gold.removeCurrency(9);
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
        if (playerInventory.container.gold.canAfford(9))
        {
            playerInventory.container.gold.removeCurrency(9);
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
        if (playerInventory.container.gold.canAfford(5))
        {
            playerInventory.container.gold.removeCurrency(5);
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
        if (playerInventory.container.gold.canAfford(7))
        {
            playerInventory.container.gold.removeCurrency(7);
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
        if (playerInventory.container.gold.canAfford(5))
        {
            playerInventory.container.gold.removeCurrency(5);
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
        if (playerInventory.container.gold.canAfford(7))
        {
            playerInventory.container.gold.removeCurrency(7);
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
        if (playerInventory.container.gold.canAfford(9))
        {
            playerInventory.container.gold.removeCurrency(9);
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
        if (playerInventory.container.gold.canAfford(5))
        {
            playerInventory.container.gold.removeCurrency(5);
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
        if (playerInventory.container.gold.canAfford(7))
        {
            playerInventory.container.gold.removeCurrency(7);
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
        if (playerInventory.container.gold.canAfford(9))
        {
            playerInventory.container.gold.removeCurrency(9);
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
        if (playerInventory.container.gold.canAfford(5))
        {
            playerInventory.container.gold.removeCurrency(5);
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
        if (playerInventory.container.gold.canAfford(7))
        {
            playerInventory.container.gold.removeCurrency(7);
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
        if (playerInventory.container.gold.canAfford(9))
        {
            playerInventory.container.gold.removeCurrency(9);
            ItemObject item = playerInventory.database.GetItem[21];
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
        playerInventory.container.gold.addCurrency(25);
    }



}
