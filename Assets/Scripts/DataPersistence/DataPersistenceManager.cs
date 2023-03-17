using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{

    [Header("Debugging")]
    [SerializeField] private bool initializeDataIfNull = false;

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    
    private GameData gameData;
    private List<IDataPersistence> dataPersistences;
    private FileDataHandler dataHandler;

    public InventoryObject playerInventory;
    public InventoryObject playerEquipment;


    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Found more than one DataPersistenceManager in scene. Newest destroyed.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(this.gameObject);
        
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
    {
        this.dataPersistences = FindAllDataPersistences();
        LoadGame();
    }

    public void NewGame()
    {
        Debug.Log("New Game started");
        playerInventory.Clear();
        playerEquipment.Clear();
        this.gameData = new GameData();
        this.SaveGame();
    }

    public void LoadGame()
    {
        // load game data from file with data handler
        this.gameData = dataHandler.Load();

        if(this.gameData == null && initializeDataIfNull)
        {
            NewGame();
        }

        // if there is no save data, initialize to a new game
        if(this.gameData == null)
        {
            Debug.Log("No save data found. A new game needs to be started before load");
            return;
        }

        foreach(IDataPersistence dataPersistence in dataPersistences)
        {
            dataPersistence.LoadData(gameData);
        }

        Debug.Log("Loaded Spawn Position: " + gameData.playerHP);
    }

    public void SaveGame()
    {
        if(this.gameData == null)
        {
            Debug.LogWarning("No data found. A new game must be started.");
            return;
        }

        // dataPersistences = FindAllDataPersistences();

        // pass data to other scripts to be updated
        foreach(IDataPersistence dataPersistence in dataPersistences)
        {
            // Ensure deleted instances do not get saved
            if(dataPersistence.Equals(null))
                dataPersistence.SaveData(gameData);
        }

        // save the gathered data to file with data handler
        dataHandler.Save(gameData);
        Debug.Log("Saved Player health: " + gameData.playerHP);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
        // playerInventory.Save();
        // playerEquipment.Save();
        // playerInventory.Clear();
        // playerEquipment.Clear();
        Debug.Log("Saved");
    }

    private List<IDataPersistence> FindAllDataPersistences()
    {
        IEnumerable<IDataPersistence> dataPersistences = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistences);
    }

    public bool HasGameData()
    {
        return gameData != null;
    }


}
