using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepressUI : MonoBehaviour
{ 
    public Slider slider;
    private float valueDisplay;
    private float fullDepress;

    private void Update()
    {
        UpdateSlider();
    }
    
    public void UpdateSlider()
    {
        valueDisplay = GameManger.Instance.GetPlayerData().currentDepress / fullDepress;
        slider.value = valueDisplay;
    }
}

