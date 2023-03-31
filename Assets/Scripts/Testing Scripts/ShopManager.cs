using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    private PlayerPersistency playerPersistency;

    public InventoryObject playerInventory;
    public InventoryObject playerEquipment;

    // public GameObject dataManagerObj;
    public DataPersistenceManager dataManager;

    public GameObject notEnoughFunds;
    public GameObject purchaseSuccessful;

    public int currPlayerMoney;
    public TextMeshProUGUI lblCurrentMoneyAmount;

    public GameObject playerObj;

    [Header("Upgrade Buttons")]
    [SerializeField] private GameObject helmetUpgradeBTN;
    [SerializeField] private GameObject chestUpgradeBTN;
    [SerializeField] private GameObject legsUpgradeBTN;
    [SerializeField] private GameObject bootsUpgradeBTN;
    [SerializeField] private GameObject swordUpgradeBTN;
    [SerializeField] private GameObject shieldUpgradeBTN;

    [Header("Upgrade Info Labels")]
    [SerializeField] private GameObject upgradeInfoWindow;
    [SerializeField] private TextMeshProUGUI weaponName;
    [SerializeField] private TextMeshProUGUI upgradeCost;
    [SerializeField] private TextMeshProUGUI currentBuff;
    [SerializeField] private TextMeshProUGUI upgradedBuff;
    [SerializeField] private TextMeshProUGUI weaponName2;

    [Header("Buy Buttons")]
    [SerializeField] private GameObject helmetPurchaseBtn;
    [SerializeField] private GameObject chestPurchaseBtn;
    [SerializeField] private GameObject legsPurchaseBtn;
    [SerializeField] private GameObject bootsPurchaseBtn;
    [SerializeField] private GameObject swordPurchaseBtn;
    [SerializeField] private GameObject shieldPurchaseBtn;

    [Header("Upgrade Success Display")]
    [SerializeField] private GameObject upgradeSuccessDisplay;


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

        if (playerEquipment.container.Items[0].item.ID != -1 && playerEquipment.container.Items[0].item.buffs[0].IsUpgradable())
        {
            helmetUpgradeBTN.SetActive(true);
        }
        else
        {
            helmetUpgradeBTN.SetActive(false);
        }

        if (playerEquipment.container.Items[1].item.ID != -1 && playerEquipment.container.Items[1].item.buffs[0].IsUpgradable())
        {
            chestUpgradeBTN.SetActive(true);
        }
        else
        {
            chestUpgradeBTN.SetActive(false);
        }

        if (playerEquipment.container.Items[2].item.ID != -1 && playerEquipment.container.Items[2].item.buffs[0].IsUpgradable())
        {
            legsUpgradeBTN.SetActive(true);
        }
        else
        {
            legsUpgradeBTN.SetActive(false);
        }

        if (playerEquipment.container.Items[3].item.ID != -1 && playerEquipment.container.Items[3].item.buffs[0].IsUpgradable())
        {
            bootsUpgradeBTN.SetActive(true);
        }
        else
        {
            bootsUpgradeBTN.SetActive(false);
        }

        if (playerEquipment.container.Items[4].item.ID != -1 && playerEquipment.container.Items[4].item.buffs[0].IsUpgradable())
        {
            swordUpgradeBTN.SetActive(true);
        }
        else
        {
            swordUpgradeBTN.SetActive(false);
        }

        if (playerEquipment.container.Items[5].item.ID != -1 && playerEquipment.container.Items[5].item.buffs[0].IsUpgradable())
        {
            shieldUpgradeBTN.SetActive(true);
        }
        else
        {
            shieldUpgradeBTN.SetActive(false);
        }
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

    private void calculateHelmet()
    {
        weaponName.text = playerEquipment.container.Items[0].item.Name;
        int cost = calculateUpgrade(0);
        upgradeCost.text = cost.ToString();
        currentBuff.text = playerEquipment.container.Items[0].item.buffs[0].value.ToString();
        upgradedBuff.text = playerEquipment.container.Items[0].item.buffs[0].Max.ToString();
        helmetPurchaseBtn.SetActive(true);
    }
    private void calculateChest()
    {
        weaponName.text = playerEquipment.container.Items[1].item.Name;
        int cost = calculateUpgrade(1);
        upgradeCost.text = cost.ToString();
        currentBuff.text = playerEquipment.container.Items[1].item.buffs[0].value.ToString();
        upgradedBuff.text = playerEquipment.container.Items[1].item.buffs[0].Max.ToString();
        chestPurchaseBtn.SetActive(true);
    }
    private void calculateLegs()
    {
        weaponName.text = playerEquipment.container.Items[2].item.Name;
        int cost = calculateUpgrade(2);
        upgradeCost.text = cost.ToString();
        currentBuff.text = playerEquipment.container.Items[2].item.buffs[0].value.ToString();
        upgradedBuff.text = playerEquipment.container.Items[2].item.buffs[0].Max.ToString();
        legsPurchaseBtn.SetActive(true);
    }
    private void calculateBoots()
    {
        weaponName.text = playerEquipment.container.Items[3].item.Name;
        int cost = calculateUpgrade(3);
        upgradeCost.text = cost.ToString();
        currentBuff.text = playerEquipment.container.Items[0].item.buffs[0].value.ToString();
        upgradedBuff.text = playerEquipment.container.Items[0].item.buffs[0].Max.ToString();
        bootsPurchaseBtn.SetActive(true);
    }
    private void calculateSword()
    {
        weaponName.text = playerEquipment.container.Items[4].item.Name;
        int cost = calculateUpgrade(4);
        upgradeCost.text = cost.ToString();
        currentBuff.text = playerEquipment.container.Items[4].item.buffs[0].value.ToString();
        upgradedBuff.text = playerEquipment.container.Items[4].item.buffs[0].Max.ToString();
        swordPurchaseBtn.SetActive(true);
    }
    private void calculateShield()
    {
        weaponName.text = playerEquipment.container.Items[5].item.Name;
        int cost = calculateUpgrade(5);
        upgradeCost.text = cost.ToString();
        currentBuff.text = playerEquipment.container.Items[5].item.buffs[0].value.ToString();
        upgradedBuff.text = playerEquipment.container.Items[5].item.buffs[0].Max.ToString();
        shieldPurchaseBtn.SetActive(true);

    }


    private void upgradeHelmet()
    {
        Upgrade(0, calculateUpgrade(0));
        upgradeSuccessDisplay.SetActive(true);
        weaponName2.text = playerEquipment.container.Items[0].item.Name;
        Invoke("hideUpgradeSuccess", 1.5f);
    }
    private void upgradeChest()
    {
        Upgrade(1, calculateUpgrade(1));
        upgradeSuccessDisplay.SetActive(true);
        weaponName2.text = playerEquipment.container.Items[1].item.Name;
        Invoke("hideUpgradeSuccess", 1.5f);
    }
    private void upgradeLegs()
    {
        Upgrade(2, calculateUpgrade(2));
        upgradeSuccessDisplay.SetActive(true);
        weaponName2.text = playerEquipment.container.Items[2].item.Name;
        Invoke("hideUpgradeSuccess", 1.5f);
    }
    private void upgradeBoots()
    {
        Upgrade(3, calculateUpgrade(3));
        upgradeSuccessDisplay.SetActive(true);
        weaponName2.text = playerEquipment.container.Items[3].item.Name;
        Invoke("hideUpgradeSuccess", 1.5f);
    }
    private void upgradeSword()
    {
        Upgrade(4, calculateUpgrade(4));
        upgradeSuccessDisplay.SetActive(true);
        weaponName2.text = playerEquipment.container.Items[4].item.Name;
        Invoke("hideUpgradeSuccess", 1.5f);
    }
    private void upgradeShield()
    {
        Upgrade(5, calculateUpgrade(5));
        upgradeSuccessDisplay.SetActive(true);
        weaponName2.text = playerEquipment.container.Items[5].item.Name;
        Invoke("hideUpgradeSuccess", 1.5f);
    }

    private int calculateUpgrade(int equipSlot)
    {
        int cost = (playerEquipment.container.Items[equipSlot].item.buffs[0].Max - playerEquipment.container.Items[equipSlot].item.buffs[0].value)*2;
        return cost;
    }

    private void Upgrade(int equipSlot, int cost)
    {
        if (playerPersistency.money.canAfford(cost))
        {
            Debug.Log("tried to purchase upgrade");
            playerPersistency.money.removeCurrency(cost);
            playerEquipment.container.Items[equipSlot].item.buffs[0].UpgradeStat(playerEquipment.container.Items[equipSlot].item.buffs[0].Max);
        }
        helmetPurchaseBtn.SetActive(false);
        chestPurchaseBtn.SetActive(false);
        legsPurchaseBtn.SetActive(false);
        bootsPurchaseBtn.SetActive(false);
        swordPurchaseBtn.SetActive(false);
        shieldPurchaseBtn.SetActive(false);
    }

    private void hideUpgradeSuccess()
    {
        upgradeSuccessDisplay.SetActive(false);
        upgradeInfoWindow.SetActive(false);
        
    }

    public void resetMoney()
    {
        playerPersistency.money.addCurrency(25);
    }



}
