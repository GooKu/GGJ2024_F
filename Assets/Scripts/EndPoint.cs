using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // GameManger.Instance.GameEnd(); //Force Open Scene GoodEnd
            Debug.Log("GoodEnd");
            SceneManager.LoadScene("GoodEndScene");
        }
    }
}
