using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button loadGameButton;


    private void Start()
    {
        if(!DataPersistenceManager.instance.HasGameData())
        {
            loadGameButton.interactable = false;
        }
    }

    public void onNewGameClicked()
    {
        DisableMenuButtons();
        DataPersistenceManager.instance.NewGame();

        SceneManager.LoadSceneAsync("Test Village Scene");
    }

    public void onLoadGameMenu()
    {
        DisableMenuButtons();
        DataPersistenceManager.instance.SaveGame();
        DataPersistenceManager.instance.playerInventory.Load();
        DataPersistenceManager.instance.playerEquipment.Load();
        SceneManager.LoadSceneAsync("Test Village Scene");
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        loadGameButton.interactable = false;
    }
}
