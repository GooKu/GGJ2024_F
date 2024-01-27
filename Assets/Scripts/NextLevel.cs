using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class NextLevel : MonoBehaviour
{
    [SerializeField] private string goalScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(goalScene);
    }
}
