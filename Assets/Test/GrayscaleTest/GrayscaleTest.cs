using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GrayscaleTest : MonoBehaviour
{
    [SerializeField] public Volume volume;

    public void UpdareGrayscale()
    {
        volume.profile.TryGet<ColorAdjustments>(out var colorAdjustments);

        var value = colorAdjustments.saturation.GetValue<float>();
        value -= 10;
        if(value < -100)
        {
            value = -100;
        }
        VolumeParameter<float> hueShift = new VolumeParameter<float>();
        hueShift.value = value;
//        Debug.Log(colorAdjustments.saturation.GetValue<float>());
        colorAdjustments.saturation.SetValue(hueShift);
//        Debug.Log(colorAdjustments.saturation.GetValue<float>());
    }

}
