using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreamUI : MonoBehaviour
{
    private ScreamItem screamItem;

    public Slider screamSlider;
    private float screamDisplay;

    public void Start()
    {
        screamItem = FindAnyObjectByType<ScreamItem>();
        //scream = GameManger.Instance.GetPlayerData().currentScream;
    }

    public void Update()
    {
        SliderUpdate();
        //Debug.Log(screamDisplay);
    }

    public void SliderUpdate()
    {
        screamDisplay = (float)screamItem.scream / screamItem.maxScream;
        screamSlider.value = screamDisplay;
    }
}
