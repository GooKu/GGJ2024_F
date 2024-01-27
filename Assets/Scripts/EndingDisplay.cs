using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingDisplay : MonoBehaviour
{
    public GameObject FailEndUI, GoodEndUI, NormalEnd;
    private int depressScore, screamScore;

    public void EndingUIDisplay(int depressScore)
    {
        if(depressScore > 0){
            NormalEnd.SetActive(true);

            FailEndUI.SetActive(false);
            GoodEndUI.SetActive(false);
        }

        else if (depressScore >= 100)
        {
            FailEndUI.SetActive(true);

            GoodEndUI.SetActive(false);
            NormalEnd.SetActive(false);
        }

        else if(depressScore <= 0)
        {
            GoodEndUI.SetActive(true);

            FailEndUI.SetActive(false);
            NormalEnd.SetActive(false);
        }
    }
}
