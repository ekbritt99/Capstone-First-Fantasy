using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlotsMenu : MonoBehaviour
{
    [Header("Menu Navigation")]
    [SerializeField] private MainMenu mainMenu;

    [Header("Menu Buttons")]
    [SerializeField] private Button backButton;

    private SaveSlot[] saveSlots;

    private bool isLoadingGame = false;

    private void Awake()
    {
        saveSlots = GetComponentsInChildren<SaveSlot>();
    }

    public void OnBackClicked()
    {
        mainMenu.ActivateMenu();
        this.DeactivateMenu();
    }

    // Activate the save slot menu and set the save slot buttons to be interactable depending on if we are loading a game or not.
    public void ActivateMenu(bool isLoadingGame)
    {
        // Show the menu
        this.gameObject.SetActive(true);

        // Set the loading game flag
        this.isLoadingGame = isLoadingGame;

        // Load all profiles
        Dictionary<string, GameData> profiles = DataPersistenceManager.instance.GetAllProfilesData();

        // Loop each save slot in UI and set content
        foreach(SaveSlot slot in saveSlots)
        {
            // Get the profile data for this slot
            GameData data = null;
            profiles.TryGetValue(slot.GetProfileID(), out data);

            // Set the data
            slot.SetData(data);

            // Set the slot button to be interactable if there is data and we are loading a game or there is no data and we are not loading a game
            slot.SetInteractable((data != null && isLoadingGame) || (data == null && !isLoadingGame));
        }

        
    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }

    // Called when a save slot is clicked.
    public void OnSaveSlotClicked(SaveSlot slot)
    {

        // Change the profile to the one clicked
        DataPersistenceManager.instance.ChangeProfile(slot.GetProfileID());

        // Start new game if not loading
        if(!isLoadingGame)
        {
            DataPersistenceManager.instance.NewGame();
            mainMenu.ShowTutorial();
            this.DeactivateMenu();
            return;
        }

        DataPersistenceManager.instance.playerEquipment.Load();
        DataPersistenceManager.instance.playerInventory.Load();

        // Go to the game scene
        GameManager.Instance.GoToGameScene(Scenes.HOUSE);
    }

    public void DisableMenuButtons()
    {
        foreach(SaveSlot slot in saveSlots)
        {
            slot.SetInteractable(false);
        }
        backButton.interactable = false;
    }

}
