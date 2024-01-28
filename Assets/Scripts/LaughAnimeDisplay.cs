using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaughAnimeDisplay : MonoBehaviour
{
    //public GameObject image1, image2;
    public GameObject laugh1, laugh2;
    //public bool run;

    private void Start()
    {
        laugh1.SetActive(false);
        laugh2.SetActive(false);
    }
    
    public void LaughAnimeRun()
    {
        //if (run)
        //{
            laugh1.SetActive(true);
            laugh2.SetActive(true);
            //run = false;
        //}
    }

    /*public void Update()
    {
        LaughAnimeRun();
    } */
}
