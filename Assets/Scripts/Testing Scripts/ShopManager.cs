using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public InventoryObject playerInventory;

    public GameObject dataManagerObj;
    public DataPersistenceManager dataManager;

    public GameObject notEnoughFunds;
    public GameObject purchaseSuccessful;

    // Start is called before the first frame update
    void Start()
    {
        dataManager = dataManagerObj.GetComponent<DataPersistenceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void purchaseKatana()
    {
        if (dataManager.getMoneyAmount() >= 5)
        {
            dataManager.purchaseWeapon5();
            playerInventory.container.Items[4].item.ID = 1;
            playerInventory.container.Items[4].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }
        
    }

    public void purchaseMace()
    {
        if (dataManager.getMoneyAmount() >= 5)
        {
            dataManager.purchaseWeapon5();
            playerInventory.container.Items[4].item.ID = 3;
            playerInventory.container.Items[4].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }

    public void purchaseScimitar()
    {
        if (dataManager.getMoneyAmount() >= 5)
        {
            dataManager.purchaseWeapon5();
            playerInventory.container.Items[4].item.ID = 5;
            playerInventory.container.Items[4].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }

    public void purchaseRomanSword()
    {
        if (dataManager.getMoneyAmount() >= 5)
        {
            dataManager.purchaseWeapon5();
            playerInventory.container.Items[4].item.ID = 4;
            playerInventory.container.Items[4].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }




    public void purchasePlatinumArmor()
    {
        if (dataManager.getMoneyAmount() >= 11)
        {
            dataManager.purchaseWeapon11();
            playerInventory.container.Items[1].item.ID = 9;
            playerInventory.container.Items[1].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseBasicArmor()
    {
        if (dataManager.getMoneyAmount() >= 5)
        {
            dataManager.purchaseWeapon5();
            playerInventory.container.Items[1].item.ID = 6;
            playerInventory.container.Items[1].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseBronzeArmor()
    {
        if (dataManager.getMoneyAmount() >= 7)
        {
            dataManager.purchaseWeapon7();
            playerInventory.container.Items[1].item.ID = 7;
            playerInventory.container.Items[1].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseIronArmor()
    {
        if (dataManager.getMoneyAmount() >= 9)
        {
            dataManager.purchaseWeapon9();
            playerInventory.container.Items[1].item.ID = 8;
            playerInventory.container.Items[1].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }


    public void purchaseIronBoots()
    {
        if (dataManager.getMoneyAmount() >= 9)
        {
            dataManager.purchaseWeapon9();
            playerInventory.container.Items[3].item.ID = 12;
            playerInventory.container.Items[3].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseLeatherBoots()
    {
        if (dataManager.getMoneyAmount() >= 5)
        {
            dataManager.purchaseWeapon5();
            playerInventory.container.Items[3].item.ID = 10;
            playerInventory.container.Items[3].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseStuddedBoots()
    {
        if (dataManager.getMoneyAmount() >= 7)
        {
            dataManager.purchaseWeapon7();
            playerInventory.container.Items[3].item.ID = 11;
            playerInventory.container.Items[3].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }





    public void purchaseWoodenShield()
    {
        if (dataManager.getMoneyAmount() >= 5)
        {
            dataManager.purchaseWeapon5();
            playerInventory.container.Items[5].item.ID = 13;
            playerInventory.container.Items[5].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseKiteShield()
    {
        if (dataManager.getMoneyAmount() >= 7)
        {
            dataManager.purchaseWeapon7();
            playerInventory.container.Items[5].item.ID = 14;
            playerInventory.container.Items[5].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseTowerShield()
    {
        if (dataManager.getMoneyAmount() >= 9)
        {
            dataManager.purchaseWeapon9();
            playerInventory.container.Items[5].item.ID = 15;
            playerInventory.container.Items[5].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }





    public void purchaseLeatherPants()
    {
        if (dataManager.getMoneyAmount() >= 5)
        {
            dataManager.purchaseWeapon5();
            playerInventory.container.Items[2].item.ID = 16;
            playerInventory.container.Items[2].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseStuddedPants()
    {
        if (dataManager.getMoneyAmount() >= 7)
        {
            dataManager.purchaseWeapon7();
            playerInventory.container.Items[2].item.ID = 17;
            playerInventory.container.Items[2].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseChainmailPants()
    {
        if (dataManager.getMoneyAmount() >= 9)
        {
            dataManager.purchaseWeapon9();
            playerInventory.container.Items[2].item.ID = 18;
            playerInventory.container.Items[2].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }

    public void purchaseStuddedHelmet()
    {
        if (dataManager.getMoneyAmount() >= 5)
        {
            dataManager.purchaseWeapon5();
            playerInventory.container.Items[0].item.ID = 19;
            playerInventory.container.Items[0].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }

    public void purchaseHornedHelmet()
    {
        if (dataManager.getMoneyAmount() >= 7)
        {
            dataManager.purchaseWeapon7();
            playerInventory.container.Items[0].item.ID = 20;
            playerInventory.container.Items[0].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
    public void purchaseKnightHelmet()
    {
        if (dataManager.getMoneyAmount() >= 9)
        {
            dataManager.purchaseWeapon9();
            playerInventory.container.Items[0].item.ID = 21;
            playerInventory.container.Items[0].AddAmount(1);
            purchaseSuccessful.SetActive(true);
        }
        else
        {
            notEnoughFunds.SetActive(true);
        }

    }
}
