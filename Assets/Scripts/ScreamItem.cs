using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamItem : MonoBehaviour
{
    public int scream, touchAdd = 20;
    public ScreamUI screamUI;

    private void Start()
    {
        screamUI = FindAnyObjectByType<ScreamUI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            scream += touchAdd;
            screamUI.SliderUpdate();
            
            GameManger.Instance.GetPlayerData().currentScream += scream;

            Debug.Log("S" + GameManger.Instance.GetPlayerData().currentScream);
            Debug.Log("D" + GameManger.Instance.GetPlayerData().currentDepress);
            Destroy(gameObject);
        }
    }
}
