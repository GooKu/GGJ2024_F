using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int touchDamage;
    private PlayerDepress playerDepress;

    void Start()
    {
        playerDepress = GameObject.FindAnyObjectByType<PlayerDepress>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            if(playerDepress)
            {
                playerDepress.PlayerGetDamage(touchDamage);
            }
        }
    }
}
