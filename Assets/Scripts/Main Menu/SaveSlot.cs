using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private string profileID = "";

    [Header("Content")]
    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;
    [SerializeField] private TMPro.TextMeshProUGUI healthText;
    [SerializeField] private TMPro.TextMeshProUGUI moneyText;

    [SerializeField] private InventoryObject equipment;
    [SerializeField] private DisplaySaveEquipment displaySaveEquipment;

    private Button saveSlotButton;

    [SerializeField] private Button deleteButton;

    private void Awake()
    {
        saveSlotButton = GetComponent<Button>();
        displaySaveEquipment.inventory = InventoryObject.Instantiate<InventoryObject>(equipment);
    }

    public void SetData(GameData data)
    {
        // Show the correct content depending on if there is data or not
        if(data == null)
        {
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
            deleteButton.interactable = false;
            displaySaveEquipment.inventory.Clear();
            displaySaveEquipment.Display();
        }
        else
        {
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);
            deleteButton.interactable = true;

            // Set the data
            healthText.text = "HP: " + data.playerHP.ToString();
            moneyText.text = "Gold: " + data.money.ToString();
            
            displaySaveEquipment.inventory.Load(profileID);

            displaySaveEquipment.Display();

        }
    }

    public string GetProfileID()
    {
        return profileID;
    }

    public void SetInteractable(bool interactable)
    {
        saveSlotButton.interactable = interactable;
    }
}
