﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum InGamePos {
        Front,
        Library,
        Kitchen,
        Badroom,
        Bathroom
    };

    public InGamePos userPos=InGamePos.Front;

    public bool IsStart = true;
    public bool IsReset = false;
    DataManager DataManager;
    void Start()
    {
        DataManager = SingletonContainer.instance.GetComponentInChildren<DataManager>();
        if (FindObjectOfType<GameParameter>() != null)
        {
            FindObjectOfType<GameManager>().IsReset = FindObjectOfType<GameParameter>().IsReset;
            Destroy(FindObjectOfType<GameParameter>());
        }
        if (IsReset)
        {
            DataManager.ResetData();
            IsReset = false;
        }
        DataManager.LoadGameData();
    }

    public void getInit() //다른 씬으로 이동했을때 호출
    {
        if (!IsStart)
        {
            IsReset = true;
            DataManager.SaveGameData();
            DataManager.LoadGameData();
            IsReset = false;
        }
    }


}
