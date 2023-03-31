using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public enum Scenes { MAIN_MENU, HOUSE, VILLAGE, INVENTORY, WORLD, BATTLE, SHOP, WORLD2 }
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

    public GameObject pauseMenu;
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
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
        if (pauseMenu.activeInHierarchy)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }


    public void GoToGameScene(Scenes scene)
    {
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
                }

                if (scene == Scenes.WORLD && SceneManager.GetActiveScene().name == "World Scene 2")
                {
                    PlayerPersistency.Instance.spawnPosition = new Vector3(positionHistory.x, 4f, 1.565f);
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
               

            GameObject player = GameObject.Find("Player");
            // Debug.Log("Player: " + player.gameObject.transform.position);
            Vector3 temp = player.transform.position;
            Debug.Log("GoToPreviousScene spawn position: " + positionHistory);
            PlayerPersistency.Instance.spawnPosition = positionHistory;
            positionHistory = temp;
            
        }

        DataPersistenceManager.instance.SaveGame();

        SceneManager.LoadScene((int) prevScene);

        (prevScene, sceneState) = (sceneState, prevScene);

        // DataPersistenceManager.instance.SaveGame();

        Debug.Log("Previous Scene: " + prevScene + " -- Scene State: " + sceneState);

    }

    // IEnumerator WaitForLoadPrevScene(Scenes scene)
    // {
    //     SceneManager.LoadScene((int) scene);
    //     while(SceneManager.GetActiveScene().buildIndex != (int) scene)
    //     {
    //         yield return null;
    //     }

    //     if(gameState == GameState.ACTIVE)
    //     {
    //         GameObject player = GameObject.Find("Player");
    //         Debug.Log("Player: " + player.gameObject.transform.position);
    //         Vector3 temp = player.transform.position;
    //         player.transform.position = positionHistory;
    //         positionHistory = temp;
    //     }
        
    //     (prevScene, sceneState) = (sceneState, prevScene);

    //     Debug.Log("Previous Scene: " + prevScene + " -- Scene State: " + sceneState);
    // }


    public void DisplayDialogueBox(string text)
    {
        dialogueBox.GetComponentInChildren<TextMeshProUGUI>().text = text;
        dialogueBox.SetActive(true);
    }

    public void HideDialogeBox()
    {
        dialogueBox.SetActive(false);
    }

    public void ResetTempDisplays()
    {
        HideDialogeBox();
    }

    public void OnApplicationQuit()
    {
        GameManager._instance = null;
    }

}



// TODO: was working on getting spawning in the correct spot to work. Currently doesn't because the scene loads slower than gameobject.find works