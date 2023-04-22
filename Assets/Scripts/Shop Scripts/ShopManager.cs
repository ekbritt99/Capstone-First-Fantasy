using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    [Header("Equipment Slots")]
    [SerializeField] private GameObject helmetSlot;
    [SerializeField] private GameObject chestSlot;
    [SerializeField] private GameObject legsSlot;
    [SerializeField] private GameObject bootsSlot;
    [SerializeField] private GameObject swordSlot;
    [SerializeField] private GameObject shieldSlot;
    [SerializeField] private GameObject hpButton;

    [Header("Purchase Menus")]
    [SerializeField] private GameObject helmetMenu;
    [SerializeField] private GameObject chestMenu;
    [SerializeField] private GameObject legsMenu;
    [SerializeField] private GameObject bootsMenu;
    [SerializeField] private GameObject swordMenu;
    [SerializeField] private GameObject shieldMenu;
    [SerializeField] private GameObject hpMenu;


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

    [Header("Upgrade Success/Not Enough Funds Display")]
    [SerializeField] private GameObject upgradeSuccessDisplay;
    [SerializeField] private GameObject notEnoughFundsUpgradeDisplay;


    // Start is called before the first frame update
    void Start()
    {
        playerPersistency = GameObject.Find("PlayerPersistency").GetComponent<PlayerPersistency>();
        // dataManager = dataManagerObj.GetComponent<DataPersistenceManager>();
        //get current player money here

        // lblCurrentMoneyAmount.text = "Test";

        helmetSlot.GetComponent<Button>().onClick.AddListener(delegate { showPurchaseMenu(true, false, false, false, false, false, false); });
        chestSlot.GetComponent<Button>().onClick.AddListener(delegate { showPurchaseMenu(false, true, false, false, false, false, false); });
        legsSlot.GetComponent<Button>().onClick.AddListener(delegate { showPurchaseMenu(false, false, true, false, false, false, false); });
        bootsSlot.GetComponent<Button>().onClick.AddListener(delegate { showPurchaseMenu(false, false, false, true, false, false, false); });
        swordSlot.GetComponent<Button>().onClick.AddListener(delegate { showPurchaseMenu(false, false, false, false, true, false, false); });
        shieldSlot.GetComponent<Button>().onClick.AddListener(delegate { showPurchaseMenu(false, false, false, false, false, true, false); });
        hpButton.GetComponent<Button>().onClick.AddListener(delegate { showPurchaseMenu(false, false, false, false, false, false, true); });


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
            autoEquip(item, 4);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }

    public void purchaseMace()
    {
        if (playerPersistency.money.canAfford(5))
        {
            playerPersistency.money.removeCurrency(5);
            ItemObject item = playerInventory.database.GetItem[3];
            autoEquip(item, 4);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }

    public void purchaseScimitar()
    {
        if (playerPersistency.money.canAfford(5))
        {
            playerPersistency.money.removeCurrency(5);
            ItemObject item = playerInventory.database.GetItem[5];
            autoEquip(item, 4);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }

    public void purchaseRomanSword()
    {
        if (playerPersistency.money.canAfford(5))
        {
            playerPersistency.money.removeCurrency(5);
            ItemObject item = playerInventory.database.GetItem[4];
            autoEquip(item, 4);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }




    public void purchasePlatinumArmor()
    {
        if (playerPersistency.money.canAfford(11))
        {
            playerPersistency.money.removeCurrency(11);
            ItemObject item = playerInventory.database.GetItem[9];
            autoEquip(item, 1);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }
    public void purchaseBasicArmor()
    {
        if (playerPersistency.money.canAfford(5))
        {
            playerPersistency.money.removeCurrency(5);
            ItemObject item = playerInventory.database.GetItem[6];
            autoEquip(item, 1);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }
    public void purchaseBronzeArmor()
    {
        if (playerPersistency.money.canAfford(7))
        {
            playerPersistency.money.removeCurrency(7);
            ItemObject item = playerInventory.database.GetItem[7];
            autoEquip(item, 1);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }
    public void purchaseIronArmor()
    {
        if (playerPersistency.money.canAfford(9))
        {
            playerPersistency.money.removeCurrency(9);
            ItemObject item = playerInventory.database.GetItem[8];
            autoEquip(item, 1);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }


    public void purchaseIronBoots()
    {
        if (playerPersistency.money.canAfford(9))
        {
            playerPersistency.money.removeCurrency(9);
            ItemObject item = playerInventory.database.GetItem[12];
            autoEquip(item, 3);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }
    public void purchaseLeatherBoots()
    {
        if (playerPersistency.money.canAfford(5))
        {
            playerPersistency.money.removeCurrency(5);
            ItemObject item = playerInventory.database.GetItem[10];
            autoEquip(item, 3);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }
    public void purchaseStuddedBoots()
    {
        if (playerPersistency.money.canAfford(7))
        {
            playerPersistency.money.removeCurrency(7);
            ItemObject item = playerInventory.database.GetItem[11];
            autoEquip(item, 3);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }





    public void purchaseWoodenShield()
    {
        if (playerPersistency.money.canAfford(5))
        {
            playerPersistency.money.removeCurrency(5);
            ItemObject item = playerInventory.database.GetItem[13];
            autoEquip(item, 5);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }
    public void purchaseKiteShield()
    {
        if (playerPersistency.money.canAfford(7))
        {
            playerPersistency.money.removeCurrency(7);
            ItemObject item = playerInventory.database.GetItem[14];
            autoEquip(item, 5);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }
    public void purchaseTowerShield()
    {
        if (playerPersistency.money.canAfford(9))
        {
            playerPersistency.money.removeCurrency(9);
            ItemObject item = playerInventory.database.GetItem[15];
            autoEquip(item, 5);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }





    public void purchaseLeatherPants()
    {
        if (playerPersistency.money.canAfford(5))
        {
            playerPersistency.money.removeCurrency(5);
            ItemObject item = playerInventory.database.GetItem[16];
            autoEquip(item, 2);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }
    public void purchaseStuddedPants()
    {
        if (playerPersistency.money.canAfford(7))
        {
            playerPersistency.money.removeCurrency(7);
            ItemObject item = playerInventory.database.GetItem[17];
            autoEquip(item, 2);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }
    public void purchaseChainmailPants()
    {
        if (playerPersistency.money.canAfford(9))
        {
            playerPersistency.money.removeCurrency(9);
            ItemObject item = playerInventory.database.GetItem[18];
            autoEquip(item, 2);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }

    public void purchaseStuddedHelmet()
    {
        if (playerPersistency.money.canAfford(5))
        {
            playerPersistency.money.removeCurrency(5);
            ItemObject item = playerInventory.database.GetItem[19];
            autoEquip(item, 0);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }

    public void purchaseHornedHelmet()
    {
        if (playerPersistency.money.canAfford(7))
        {
            playerPersistency.money.removeCurrency(7);
            ItemObject item = playerInventory.database.GetItem[20];
            autoEquip(item, 0);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }
    public void purchaseKnightHelmet()
    {
        if (playerPersistency.money.canAfford(9))
        {
            playerPersistency.money.removeCurrency(9);
            ItemObject item = playerInventory.database.GetItem[21];
            autoEquip(item, 0);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }

    public void purchaseHardyStew()
    {
        if (playerPersistency.money.canAfford(3))
        {
            playerPersistency.money.removeCurrency(3);
            ItemObject item = playerInventory.database.GetItem[24];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }
    }

        public void purchaseRedPotion()
        {
            if (playerPersistency.money.canAfford(5))
            {
                playerPersistency.money.removeCurrency(5);
                ItemObject item = playerInventory.database.GetItem[0];
                playerInventory.AddItem(item.CreateItem(), 1);
                purchaseSuccessful.SetActive(true);
                Invoke("hidePurchaseSuccessful", 1.5f);
            }
            else
            {
                notEnoughFunds.SetActive(true);
                Invoke("hideNotEnoughFundsPurchase", 1.5f);
            }

        }

    public void purchaseStrangeBrew()
    {
        if (playerPersistency.money.canAfford(7))
        {
            playerPersistency.money.removeCurrency(7);
            ItemObject item = playerInventory.database.GetItem[2];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
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
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
        }

    }

    public void purchaseElixirOfTheGods()
    {
        if (playerPersistency.money.canAfford(15))
        {
            playerPersistency.money.removeCurrency(15);
            ItemObject item = playerInventory.database.GetItem[23];
            playerInventory.AddItem(item.CreateItem(), 1);
            purchaseSuccessful.SetActive(true);
            Invoke("hidePurchaseSuccessful", 1.5f);
        }
        else
        {
            notEnoughFunds.SetActive(true);
            Invoke("hideNotEnoughFundsPurchase", 1.5f);
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
        currentBuff.text = playerEquipment.container.Items[3].item.buffs[0].value.ToString();
        upgradedBuff.text = playerEquipment.container.Items[3].item.buffs[0].Max.ToString();
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

            helmetPurchaseBtn.SetActive(false);
            chestPurchaseBtn.SetActive(false);
            legsPurchaseBtn.SetActive(false);
            bootsPurchaseBtn.SetActive(false);
            swordPurchaseBtn.SetActive(false);
            shieldPurchaseBtn.SetActive(false);
        }
        else
        {
            notEnoughFundsUpgradeDisplay.SetActive(true);
            Invoke("hideNotEnoughFundsUpgrade", 1.5f);        
        }
           
    }

    private void hideUpgradeSuccess()
    {
        upgradeSuccessDisplay.SetActive(false);
        upgradeInfoWindow.SetActive(false);
        
    }

    private void hideNotEnoughFundsUpgrade()
    {
        notEnoughFundsUpgradeDisplay.SetActive(false);
    }

    private void hideNotEnoughFundsPurchase()
    {
        notEnoughFunds.SetActive(false);
    }

    private void hidePurchaseSuccessful()
    {
        purchaseSuccessful.SetActive(false);
    }

    public void resetMoney()
    {
        playerPersistency.money.addCurrency(25);
    }

    public void useTestingPlayerPersistency(PlayerPersistency testingPersistency)
    {
        playerPersistency = testingPersistency;
    }

    public void purchaseKnightHelmetTest()
    {
        if (playerPersistency.money.canAfford(9))
        {
            playerPersistency.money.removeCurrency(9);
        }
    }

    public void showPurchaseMenu(bool helmet, bool chest, bool legs, bool boots, bool sword, bool shield, bool hp)
    {
        helmetMenu.SetActive(helmet);
        chestMenu.SetActive(chest);
        legsMenu.SetActive(legs);
        bootsMenu.SetActive(boots);
        swordMenu.SetActive(sword);
        shieldMenu.SetActive(shield);
        hpMenu.SetActive(hp);
    }

    public void autoEquip(ItemObject item, int slot)
    {
        if (playerEquipment.container.Items[slot].item.ID == -1)
        {
            playerEquipment.container.Items[slot].item = item.CreateItem();
        }
        else
        {
            playerInventory.AddItem(item.CreateItem(), 1);
        }
    }

}
