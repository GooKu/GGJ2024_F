using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingDisplay : MonoBehaviour
{
    public GameObject FailEndUI, GoodEndUI, NormalEnd;

    public void EndingUIDisplay(int depressScore)
    {
        NormalEnd.SetActive(depressScore > 0);
        FailEndUI.SetActive(depressScore >= 100);
        GoodEndUI.SetActive(depressScore <= 0);
        
        FailEndUI.SetActive(FailEndUI.activeSelf && !(depressScore >= 100));
        GoodEndUI.SetActive(GoodEndUI.activeSelf && !(depressScore <= 0));
        NormalEnd.SetActive(NormalEnd.activeSelf && !FailEndUI.activeSelf && !GoodEndUI.activeSelf);
    }
}
