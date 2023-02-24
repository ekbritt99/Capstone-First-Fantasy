using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public InventoryObject playerInventory;


    public string villageScene = "Test Village Scene";
    public string overworldScene = "Test World Scene";
    public string battleScene = "Battle Scene";
    public string inventoryScene = "InventoryUI Scene";
    public string shopScene = "Shop Scene";

    bool pause = false;
    public GameObject pauseMenu;

    public GameObject swordUpgradeMenu;

    public GameObject dataManager;

    public TMP_Text lblCurrentMoneyAmount; 

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Pause();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GoToInventory();
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            playerInventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            playerInventory.Load();
        }

        if (SceneManager.GetActiveScene().name == "Shop Scene" || SceneManager.GetActiveScene().name == "Test Village Scene")
        {
            lblCurrentMoneyAmount.text = dataManager.GetComponent<DataPersistenceManager>().getMoneyAmount().ToString();
        }
        

    }

    void Pause()
    {
        pauseMenu.SetActive(!pause);
        if (!pause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        pause = !pause;
    }


    void openSwordUpgradeMenu()
    {
        swordUpgradeMenu.SetActive(true);
    }

    void GoToVillage()
    {
        SceneManager.LoadScene(villageScene);
    }

    void GoToOverWorld()
    {
        SceneManager.LoadScene(overworldScene);
    }
    void GoToBattle()
    {
        SceneManager.LoadScene(battleScene);
    }
    void GoToInventory()
    {
        SceneManager.LoadScene(inventoryScene);
    }
    void GoToShop()
    {
        dataManager.GetComponent<DataPersistenceManager>().SaveGame();
        SceneManager.LoadScene(shopScene);
    }
    void Quit()
    {
        Application.Quit(0);
    }

    // private void OnApplicationQuit()
    // {
    //     playerInventory.container.Items = new InventorySlot[25];
    // }
}
