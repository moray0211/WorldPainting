using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataManager : MonoBehaviour
{
    /*
    static GameObject _container;
    static GameObject Container
    {
        get
        {
            return _container;
        }
    }
    static DataManager _instance;
    public static DataManager instance
    {
        get
        {
            if (!_instance)
            {
                _container = new GameObject();
                _container.name = "DataManager";
                _instance = _container.AddComponent(typeof(DataManager)) as DataManager;
                DontDestroyOnLoad(_container);
            }
            return _instance;
        }
    }
    */
    public string SaveFileName = ".json";
    public GameData _gameData;
    public GameData gameData
    {
        get
        {
            if (_gameData == null)
            {
                LoadGameData();
                SaveGameData();
            }
            return _gameData;
        }
    }

    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + SaveFileName;
        if (File.Exists(filePath))
        {
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<GameData>(FromJsonData);
            LoadInventoryData();
        }
        else
        {
            _gameData = new GameData();
        }
    }

    public void SaveGameData()
    {
        SaveInventoryData();

        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + SaveFileName;
        File.WriteAllText(filePath, ToJsonData);
    }

    public void SaveInventoryData()
    {
        _gameData.inventory_items = Inventory.instance.items.ToArray();
    }

    public void LoadInventoryData()
    {
        for(int i=0;i< _gameData.inventory_items.Length; i++)
        {
            Inventory.instance.Add(_gameData.inventory_items[i]);
        }
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }

    public void ResetData()
    {
        string filePath = Application.persistentDataPath + SaveFileName;
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            ResetALLSwitches();
            ResetALLItems();
        }
    }

    public void ResetALLSwitches()
    {
        object[] switches = Resources.LoadAll("Switches");
        for(int i=0;i< switches.Length ; i++)
        {
            Switch tem = switches[i] as Switch;
            tem.setSwitchActive(false);
        }
    }
    public void ResetALLItems()
    {
        object[] items = Resources.LoadAll("Items");
        //Debug.Log(items.Length + "개의 아이템 리셋");
        for (int i = 0; i < items.Length; i++)
        {
            Item tem = items[i] as Item;
            tem.setItemDestory(false);
        }
    }
}


