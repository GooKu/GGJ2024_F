using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamItem : MonoBehaviour
{
    public static int changeScream = 20;
    public int scream = 0, maxScream = 100;

    private void Start()
    {
        //scream = GameManger.Instance.GetPlayerData().currentScream;   
    }

    private void Update()
    {
        if( scream >= maxScream)
        {
            scream = maxScream;
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag("Player")) //&& collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D"
        {
            scream += changeScream;
            Destroy(gameObject);
        }
    }
}
