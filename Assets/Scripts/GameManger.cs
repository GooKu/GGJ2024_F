using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            DestroyImmediate(gameObject);
            return;
        }
    }

    public void StartGame()
    {
        //TODO
    }

    public PlayerData GetPlayerData()
    {
        throw new NotImplementedException();
    }
}
