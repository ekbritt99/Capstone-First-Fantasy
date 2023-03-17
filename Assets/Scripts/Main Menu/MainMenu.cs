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
    [SerializeField] private GameObject tutorial;


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

        tutorial.SetActive(true);
    }

    public void onLoadGameMenu()
    {
        DisableMenuButtons();
        DataPersistenceManager.instance.SaveGame();
        DataPersistenceManager.instance.playerEquipment.Load();
        DataPersistenceManager.instance.playerInventory.Load();
        GameManager.Instance.GoToGameScene(Scenes.HOUSE);
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        loadGameButton.interactable = false;
    }


    public void onTutorialStartGameClicked()
    {
        DataPersistenceManager.instance.NewGame();
        GameManager.Instance.GoToGameScene(Scenes.HOUSE);
    }
}
