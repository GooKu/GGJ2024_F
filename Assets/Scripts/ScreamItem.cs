using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            GameManger.Instance.GetPlayerData().currentScream += 20;
            Destroy(gameObject);
        }
    }
}
