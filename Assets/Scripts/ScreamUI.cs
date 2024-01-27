using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreamUI : MonoBehaviour
{
    private ScreamItem screamItem;

    public Slider screamSlider;
    private float scream, maxScream = 100, screamDisplay;

    public void Start()
    {
        scream = GameManger.Instance.GetPlayerData().currentScream;
    }
    
    public void SliderUpdate()
    {
        screamDisplay = (float)screamItem.scream / maxScream;
        screamSlider.value = screamDisplay;
    }
}
