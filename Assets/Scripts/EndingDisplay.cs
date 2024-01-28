using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingDisplay : MonoBehaviour
{
    public GameObject FailEndUI, GoodEndUI, NormalEnd;

    private void Start()
    {
        NormalEnd.SetActive(false);
        FailEndUI.SetActive(false);
        GoodEndUI.SetActive(false);
    }

    public void EndingUIDisplay(int depressScore)
    {
        NormalEnd.SetActive(depressScore > 0 && depressScore < 100);
        GoodEndUI.SetActive(depressScore <= 0);
    }

    public void FailUIDisplay()
    {
        FailEndUI.SetActive(true);
    }
}
