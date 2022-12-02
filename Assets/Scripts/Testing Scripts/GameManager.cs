using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string villageScene = "Test Village Scene";
    public string overworldScene = "Test World Scene";
    public string battleScene = "Battle Scene";
    public string inventory = "InventoryUI Scene";

    bool pause = false;
    public GameObject pauseMenu;
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
        SceneManager.LoadScene(inventory);
    }
    void Quit()
    {
        Application.Quit(0);
    }
}
