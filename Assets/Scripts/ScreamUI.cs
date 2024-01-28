using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreamUI : MonoBehaviour
{
    public Slider screamSlider;
    public  int scream = 0;
    private int maxScream = 100;
    public float screamDisplay;

    private void Update()
    {
        SliderUpdate();
    }
    
    public void SliderUpdate()
    {
        screamDisplay = (float) scream / maxScream;
        //screamDisplay = (float)GameManger.Instance.GetPlayerData().currentScream / maxScream;

        screamSlider.value = screamDisplay;

        GameManger.Instance.GetPlayerData().currentScream = scream;
        Debug.Log("CS ="+ GameManger.Instance.GetPlayerData().currentScream);
    }
}