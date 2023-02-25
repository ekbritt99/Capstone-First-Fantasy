using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    
    private GameData gameData;
    private List<IDataPersistence> dataPersistences;
    private FileDataHandler dataHandler;


    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Found more than one DataPersistenceManager in scene");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistences = FindAllDataPersistences();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        // load game data from file with data handler
        this.gameData = dataHandler.Load();

        // if there is no save data, initialize to a new game
        if(this.gameData ==null)
        {
            Debug.Log("No save data found. Defaulting.");
            NewGame();
        }

        foreach(IDataPersistence dataPersistence in dataPersistences)
        {
            dataPersistence.LoadData(gameData);
        }

        Debug.Log("Loaded player position = " + gameData.playerPosition);
    }

    public void SaveGame()
    {
        // pass data to other scripts to be updated
        foreach(IDataPersistence dataPersistence in dataPersistences)
        {
            dataPersistence.SaveData(gameData);
        }

        // save the gathered data to file with data handler
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistences()
    {
        IEnumerable<IDataPersistence> dataPersistences = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistences);
    }

    public void purchaseWeapon5()
    {
        this.gameData.playerMoney -= 5;
        this.SaveGame();
    }
    public void purchaseWeapon7()
    {
        this.gameData.playerMoney -= 7;
        this.SaveGame();
    }
    public void purchaseWeapon9()
    {
        this.gameData.playerMoney -= 9;
        this.SaveGame();
    }

    public void purchaseWeapon11()
    {
        this.gameData.playerMoney -= 11;
        this.SaveGame();
    }

    public int getMoneyAmount()
    {
        return this.gameData.playerMoney;
    }
}
