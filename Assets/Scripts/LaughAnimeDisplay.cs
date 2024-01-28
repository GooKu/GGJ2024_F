using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaughAnimeDisplay : MonoBehaviour
{
    public GameObject laugh1, laugh2;
    public bool run;

    private void Start()
    {
        laugh1.SetActive(false);
        laugh2.SetActive(false);
    }
    
    public void LaughAnimeRun()
    {
        laugh1.SetActive(true);
        laugh2.SetActive(true);
        //Debug.Log("Run");
    }
}
