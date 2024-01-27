using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int touchDamage;
    private PlayerDepress playerDepress;

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            playerDepress = other.GetComponent<PlayerDepress>();
            if(playerDepress)
            {
                playerDepress.PlayerGetDamage(touchDamage);
            }
        }
    }
}
