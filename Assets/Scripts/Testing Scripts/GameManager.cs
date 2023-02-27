using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public string villageScene = "Test Village Scene";
    public string overworldScene = "Test World Scene";
    public string battleScene = "Battle Scene";
    public string inventoryScene = "InventoryUI Scene";
    public string shopScene = "Shop Scene";

    public InventoryInfoScreen InventoryInfoScreen;
    public ShopInfoScreen ShopInfoScreen;
    public StartInfoScreen StartInfoScreen;

    bool pause = false;
    public GameObject pauseMenu;

    public GameObject swordUpgradeMenu;

    public GameObject dataManager;

    public TMP_Text lblCurrentMoneyAmount;

    public GameObject sceneTrackerObj;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        sceneTrackerObj = GameObject.FindGameObjectWithTag("Scene Tracker");
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

        // if (SceneManager.GetActiveScene().name == "Shop Scene" || SceneManager.GetActiveScene().name == "Test Village Scene")
        // {
        //     lblCurrentMoneyAmount.text = dataManager.GetComponent<DataPersistenceManager>().getMoneyAmount().ToString();
        // }
        
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
        sceneTrackerObj.GetComponent<SceneTracker>().rememberScene();
        SceneManager.LoadScene(inventoryScene);
    }
    void GoToShop()
    {
        // dataManager.GetComponent<DataPersistenceManager>().SaveGame();
        SceneManager.LoadScene(shopScene);
    }

    //Info Screen Management
    public void OpenInventoryInfo()
    {
        InventoryInfoScreen.Setup();
    }
    public void CloseInventoryInfo()
    {
        InventoryInfoScreen.Shutdown();
    }
    public void OpenShopInfo()
    {
        ShopInfoScreen.Setup();
    }
    public void CloseShopInfo()
    {
        ShopInfoScreen.Shutdown();
    }
    public void OpenStartInfo()
    {
        StartInfoScreen.Setup();
    }
    public void CloseStartInfo()
    {
        StartInfoScreen.Shutdown();
    }
    public void StartfromInfoScreen()
    {
        GoToHouseScene();
    }
    public void GoToHouseScene()
    {
        SceneManager.LoadScene("House Scene");
    }

   public void goToPreviousScene()
    {
        int numOfScenes = sceneTrackerObj.GetComponent<SceneTracker>().sceneHistory.Count - 1;
        SceneManager.LoadScene(sceneTrackerObj.GetComponent<SceneTracker>().sceneHistory[numOfScenes]);
    }

    public void Quit()
    {
        Application.Quit(0);
    }

    private void OnApplicationQuit()
    {

    }
}
