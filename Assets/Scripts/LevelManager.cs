using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform startPos;

    private void Start()
    {
        GameManger.Instance.InitPlayer(startPos);
    }
}
