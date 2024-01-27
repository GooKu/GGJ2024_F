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
        playerData.currentDepress = 0;
        SceneManager.LoadScene("Level_1");
    }

    public GameObject InitPlayer(Transform startPost, bool vmFollow)
    {
        var player =GameObject.Instantiate(playerSample, startPost.position, Quaternion.identity);
        player.GetComponent<PlayerDepress>().DamageEvent += SetDepress;
        player.GetComponent<PlayerDepress>().DeadEvent += playerDeadHandle;

        if (vmFollow)
        {
            var vm = GameObject.FindFirstObjectByType<CinemachineVirtualCamera>();
            vm.Follow = player.transform;
        }
        return player;
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

    private void playerDeadHandle()
    {
        //TODO:play sound, music, show UI
    }
}
