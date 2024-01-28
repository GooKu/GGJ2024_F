using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance;

    [SerializeField] private GameObject playerSample;
    [Header("Sound")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip stageBGM;
    [SerializeField] private AudioClip deathBGM;

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
        audioSource.clip = stageBGM;
        audioSource.Play();
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
        var endingDisplay = GameObject.FindFirstObjectByType<EndingDisplay>();
        if (endingDisplay != null) 
        {
            endingDisplay.EndingUIDisplay(playerData.currentDepress);
        }

        audioSource.clip = deathBGM;
        audioSource.Play();
    }
}
