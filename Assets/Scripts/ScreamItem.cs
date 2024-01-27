using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamItem : MonoBehaviour
{
    public int touchAdd;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            GameManger.Instance.GetPlayerData().currentScream += touchAdd;
            Debug.Log(GameManger.Instance.GetPlayerData().currentScream);
            Destroy(gameObject);
        }
    }
}
