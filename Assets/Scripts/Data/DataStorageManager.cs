using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataStorageManager : MonoBehaviour
{
    [Header("File Storage Config")] [SerializeField]
    private string fileName;
    
    private GameData _gameData;
    private List<IDataStorage> _dataPersistenceObjects;
    private FileDataHandler _dataHandler;
    public static DataStorageManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("An error occurred:");
            Debug.LogError("Multiple Data Storage Manager instances have been initialized.");
            Debug.LogError("Error Code: DSMGR_CONFLICT");
        }

        Instance = this;

        Application.quitting += SaveGame;
    }

    private void Start()
    {
        _dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        _dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        _gameData = new GameData();
    }

    public void LoadGame()
    {
        // Load any saved data from a file using data handler
        _gameData = _dataHandler.Load();
        
        // if no data is found, initialize a new game
        if (_gameData == null)
        {
            Debug.Log("No data found in file. Initializing to defaults...");
            NewGame();
        }
        
        // Push any loaded data to all other scripts that require said data
        foreach (IDataStorage dataPersistenceObj in _dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(_gameData);
        }
        
        Debug.Log("Loaded Entropy = " + _gameData.entropy);
    }

    public void SaveGame()
    {
        // Push current temporary data to all other scripts that require said data
        foreach (IDataStorage dataPersistenceObj in _dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref _gameData);
        }
        
        Debug.Log("Saved Entropy = " + _gameData.entropy);
        // Save temporary data to a file using data handler
        _dataHandler.Save(_gameData);
    }

    private List<IDataStorage> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataStorage> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataStorage>();

        return new List<IDataStorage>(dataPersistenceObjects);
    }
}