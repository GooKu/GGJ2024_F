using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingDisplay : MonoBehaviour
{
    public PlayerDepress playerDepress;
    public GameObject FailEndUI, GoodEndUI, NormalEnd;
    private int depressScore, screamScore;

    private void Start()
    {
        playerDepress = FindAnyObjectByType<PlayerDepress>();
    }

    private void Update()
    {
        depressScore = playerDepress.depress;
        //depressScore = GameManger.Instance.GetPlayerData().currentDepress;
        //screamScore = GameManger.Instance.GetPlayerData().currentScream;

        FailEndUI.SetActive(false);
        GoodEndUI.SetActive(false);
        NormalEnd.SetActive(false);

        Debug.Log(depressScore);
        EndingUIDisplay();
    }

    private void EndingUIDisplay()
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
