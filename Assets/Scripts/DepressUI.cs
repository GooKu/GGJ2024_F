using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesHealthBar : MonoBehaviour
{ 
    public Slider slider;
    private float valueDisplay;
    private float fullDepress;
    public PlayerData playerData;

    //public GameObject healthBarUI;
    //public Camera cam;

    private void Update()
    {
        UpdateSlider();
    }
    
    public void UpdateSlider()
    {

        valueDisplay = PlayerData.currentDepress / fullDepress;
        slider.value = valueDisplay;
    }

    
    
}

