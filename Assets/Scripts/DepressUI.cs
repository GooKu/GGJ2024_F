using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepressUI : MonoBehaviour
{
    private PlayerDepress playerDepress;

    public Slider depressSlider;
    private float depressDisplay;

    public void Start()
    {
        playerDepress = FindAnyObjectByType<PlayerDepress>();
    }

    public void Update()
    {
        SliderUpdate();
        //Debug.Log(depressDisplay);
    }

    public void SliderUpdate()
    {
        depressDisplay = (float)playerDepress.depress / playerDepress.maxDepress;
        depressSlider.value = depressDisplay;
    }
}
