using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public enum Scenes { MAIN_MENU, HOUSE, VILLAGE, INVENTORY, WORLD, BATTLE, SHOP, WORLD2, CASTLE, TL_CASTLE_DOOR, TR_CASTLE_DOOR, BL_CASTLE_DOOR, BR_CASTLE_DOOR }
public enum GameState { DEFAULT, ACTIVE, INACTIVE }

public class GameManager: MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager Instance { get { return _instance; } }
    
    public Scenes sceneState { get; private set; }
    public GameState gameState { get; private set; }
    
    public Scenes prevScene;
    public List<string> enemyHistory = new List<string>();
    public Vector3 positionHistory;
    public Vector3 playerStartLocation;

    public GameObject inventoryUI;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject dialogueBox;
    public GameObject backButton;



    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);

        Debug.Log("New instance");

    }

    private void Start()
    {

        // Load PlayerPrefs
        LoadSettings();

        sceneState = (Scenes) SceneManager.GetActiveScene().buildIndex;
        prevScene = sceneState;

        if(SceneManager.GetActiveScene().buildIndex == (int) Scenes.MAIN_MENU)
            gameState = GameState.INACTIVE;
        else
            gameState = GameState.ACTIVE;

        Debug.Log("Scene at start: " + sceneState + " -- Expected: " + SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState != GameState.ACTIVE) { 
            return;
        }
        if (Input.GetButtonDown("Pause"))
        {
            Pause();
        }

        // if (SceneManager.GetActiveScene().name == "Shop Scene" || SceneManager.GetActiveScene().name == "Test Village Scene")
        // {
        //     lblCurrentMoneyAmount.text = dataManager.GetComponent<DataPersistenceManager>().getMoneyAmount().ToString();
        // }
        
    }

    void Pause()
    {
        if(this.settingsMenu.activeInHierarchy)
        {
            this.settingsMenu.SetActive(false);
            return;
        }
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
        if (pauseMenu.activeInHierarchy)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    void RetrunToMenu()
    {
        SceneManager.LoadScene((int) Scenes.MAIN_MENU);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToGameScene(Scenes scene)
    {
        Debug.Log("Going to scene: " + scene);
        if(scene == sceneState)
        {
            return;
        }

        

        ResetTempDisplays();

        

        if(scene == Scenes.MAIN_MENU)
            gameState = GameState.INACTIVE;
        else
            gameState = GameState.ACTIVE;

        DataPersistenceManager.instance.SaveGame();

        if(scene == Scenes.INVENTORY)
        {
            if(inventoryUI != null)
            {
                inventoryUI.SetActive(true);
                return;
            }
        }
        SceneManager.LoadScene((int) scene);
        

        if(gameState == GameState.ACTIVE)
        {
            GameObject player = GameObject.Find("Player");
            if(player != null)
            {
                positionHistory = player.transform.position;

                if (scene == Scenes.WORLD2)
                {
                    PlayerPersistency.Instance.spawnPosition = new Vector3(positionHistory.x, -4.25f, 1.565f);
                    // if(prevScene != Scenes.WORLD)  
                    //     GameObject.Find("EnemyBoss").SetActive(false);
                }

                if (scene == Scenes.WORLD && SceneManager.GetActiveScene().name == "World Scene 2")
                {
                    PlayerPersistency.Instance.spawnPosition = new Vector3(positionHistory.x, 4f, 1.565f);
                }

                if (scene == Scenes.WORLD && SceneManager.GetActiveScene().name == "Castle Scene")
                {
                    PlayerPersistency.Instance.spawnPosition = new Vector3(-5.054507f, -1.56f, 1.565f);
                }

                if (scene == Scenes.CASTLE && SceneManager.GetActiveScene().name == "Bottom Left Castle Room Scene")
                {
                    PlayerPersistency.Instance.spawnPosition = new Vector3(-3f, -3.9f, 1.565f);
                }

                if (scene == Scenes.CASTLE && SceneManager.GetActiveScene().name == "Bottom Right Castle Room Scene")
                {
                    PlayerPersistency.Instance.spawnPosition = new Vector3(3f, -3.9f, 1.565f);
                }

                if (scene == Scenes.CASTLE && SceneManager.GetActiveScene().name == "Top Left Castle Room Scene")
                {
                    PlayerPersistency.Instance.spawnPosition = new Vector3(-3f, 0.8f, 1.565f);
                }

                if (scene == Scenes.CASTLE && SceneManager.GetActiveScene().name == "Top Right Castle Room Scene")
                {
                    PlayerPersistency.Instance.spawnPosition = new Vector3(3f, 0.8f, 1.565f);
                }

                // switch(scene)
                // {
                //     case Scenes.HOUSE:
                //         PlayerPersistency.Instance.spawnPosition = new Vector3(1.2f, -0.1f, -3f);
                //         break;
                //     case Scenes.VILLAGE:
                //         PlayerPersistency.Instance.spawnPosition = new Vector3(6.9f,-1.0f, 1f);
                //         break;
                //     case Scenes.BATTLE:
                //         PlayerPersistency.Instance.spawnPosition = new Vector3(-5.4f, -0.5f, 1f);
                //         break;
                //     case Scenes.WORLD:
                //         PlayerPersistency.Instance.spawnPosition = new Vector3(-2.7f,-1.2f, 1f);
                //         break;
                //     default:
                //         PlayerPersistency.Instance.spawnPosition = Vector3.zero;
                //         break;
                // }
            }
        }

        

        prevScene = sceneState;
        sceneState = scene;


    }
    public string SceneString()
    {
        if(sceneState == Scenes.WORLD)
            return "World";
        if(sceneState == Scenes.WORLD2)
            return "World2";
        if(sceneState == Scenes.TL_CASTLE_DOOR || sceneState == Scenes.TR_CASTLE_DOOR || sceneState == Scenes.BL_CASTLE_DOOR || sceneState == Scenes.BR_CASTLE_DOOR)
            return "Castle";
        else
            return "None";
    }

    public void GoToPreviousScene()
    {
        ResetTempDisplays();

        
        
        if(gameState == GameState.ACTIVE)
        {
            // Ensure the player does not spawn in the shop trigger
            if(sceneState == Scenes.SHOP)
            {
                Debug.Log("Shop scene!!!");
                positionHistory = new Vector3(-5.7f, -0.3f, 1f);
            }

            if(prevScene == Scenes.WORLD2)
            {
                positionHistory = new Vector3(0.15999f,-0.93999f,0f);
            }
            else if(prevScene == Scenes.TR_CASTLE_DOOR)
            {
                positionHistory = new Vector3(-0.03999f,-1.15f,1.565f);

            }
                

            GameObject player = GameObject.Find("Player");
            // Debug.Log("Player: " + player.gameObject.transform.position);
            Vector3 temp = player.transform.position;
            Debug.Log("GoToPreviousScene spawn position: " + positionHistory);
            PlayerPersistency.Instance.spawnPosition = positionHistory;
            positionHistory = temp;
            
        }

        

        DataPersistenceManager.instance.SaveGame();

        if(prevScene == Scenes.WORLD2 || prevScene == Scenes.TR_CASTLE_DOOR)
        {
            StartCoroutine(WaitForLoadPrevScene(prevScene));
        }
        else
        {
            SceneManager.LoadScene((int) prevScene);
        }

        (prevScene, sceneState) = (sceneState, prevScene);

        // DataPersistenceManager.instance.SaveGame();

        Debug.Log("Previous Scene: " + prevScene + " -- Scene State: " + sceneState);

    }

    IEnumerator WaitForLoadPrevScene(Scenes scene)
    {
        SceneManager.LoadScene((int) scene);
        while(SceneManager.GetActiveScene().buildIndex != (int) scene)
        {
            yield return null;
        }

        if(scene == Scenes.WORLD2)
        {
            GameObject.Find("EnemyBoss").SetActive(false);
            GameObject.Find("bosstext").SetActive(false);
        }
        if(scene == Scenes.TR_CASTLE_DOOR)
        {
            GameObject.Find("EnemyBoss2").SetActive(false);
            // GameObject.Find("bosstext").SetActive(false);
        }


    }

    public void ToggleSettingsMenu()
    {
        this.settingsMenu.SetActive(!this.settingsMenu.activeSelf);
    }


    public void DisplayDialogueBox(string text)
    {
        dialogueBox.GetComponentInChildren<TextMeshProUGUI>().text = text;
        dialogueBox.SetActive(true);
    }

    public void HideDialogeBox()
    {
        dialogueBox.SetActive(false);
    }

    public void HideInventoryUI()
    {
        inventoryUI.SetActive(false);
    }

    public void ResetTempDisplays()
    {
        HideDialogeBox();
        HideInventoryUI();
    }

    // Load settings from PlayerPrefs (saved in registry)
    private void LoadSettings()
    {
        // Load Resolution
        int width = PlayerPrefs.GetInt("ScreenWidth", Screen.currentResolution.width);
        int height = PlayerPrefs.GetInt("ScreenHeight", Screen.currentResolution.height);
        int refreshRate = PlayerPrefs.GetInt("RefreshRate", Screen.currentResolution.refreshRate);
        bool isFullScreen = PlayerPrefs.GetInt("IsFullscreen", 1) == 1;

        Screen.SetResolution(width, height, isFullScreen, refreshRate);

        // Load Volume
        float volume = PlayerPrefs.GetInt("volume", 10000) / 10000f;
        AudioListener.volume = volume;
    }

    public void OnApplicationQuit()
    {
        GameManager._instance = null;
    }

}



// TODO: was working on getting spawning in the correct spot to work. Currently doesn't because the scene loads slower than gameobject.find works