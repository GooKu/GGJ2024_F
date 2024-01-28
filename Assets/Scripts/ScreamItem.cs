using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamItem : MonoBehaviour
{
    public static int touchAdd = 20;
    private ScreamUI screamUI;

    private void Start()
    {
        screamUI = FindAnyObjectByType<ScreamUI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            screamUI.scream += touchAdd;

            //GameManger.Instance.GetPlayerData().currentScream += touchAdd;
            //Debug.Log("Current Scream " + GameManger.Instance.GetPlayerData().currentScream);
            
            Destroy(gameObject);
        }
    }
}