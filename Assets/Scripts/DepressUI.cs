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
        
    }

    public void Update()
    {
        SliderUpdate();
        //Debug.Log(depressDisplay);
    }

    public void SliderUpdate()
    {
        playerDepress = FindAnyObjectByType<PlayerDepress>();
        depressDisplay = (float)playerDepress.depress / playerDepress.maxDepress;
        depressSlider.value = depressDisplay;
    }
}
