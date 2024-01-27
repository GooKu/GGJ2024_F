using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;
using UnityEngine.SceneManagement;

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
        //TODO: inti player data
        SceneManager.LoadScene("Level_1");
    }

    public void InitPlayer(Transform startPost)
    {
        var player =GameObject.Instantiate(playerSample, startPost.position, Quaternion.identity);
        var vm = GameObject.FindFirstObjectByType<CinemachineVirtualCamera>();
        vm.Follow = player.transform;
        //TODO: set player view
    }

    public void SetDepress(int value)
    {
        playerData.currentDepress = value;
    }

    public int GetDepress()
    {
        return playerData.currentDepress;
    }

    public PlayerData GetPlayerData()
    {
        return playerData;
    }
}
