using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance;

    [SerializeField] private GameObject playerSample;

    private PlayerData playerData;

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

        playerData = new();
    }

    public void StartGame()
    {
        //TODO
    }

    public void InitPlayer(Transform startPost)
    {
        var player =GameObject.Instantiate(playerSample, startPost.position, Quaternion.identity);
        var vm = GameObject.FindFirstObjectByType<CinemachineVirtualCamera>();
        vm.Follow = player.transform;
    }

    public PlayerData GetPlayerData()
    {
        return playerData;
    }
}
