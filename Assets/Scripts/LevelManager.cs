using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform startPos;
    [SerializeField] public Volume volume;

    private void Start()
    {
        var player = GameManger.Instance.InitPlayer(startPos);
        player.GetComponent<PlayerDepress>().DamageEvent += updateGrayscale;
    }

    private void updateGrayscale(int depress)
    {
        depress = -depress;
        volume.profile.TryGet<ColorAdjustments>(out var colorAdjustments);
        VolumeParameter<float> saturationShift = new VolumeParameter<float>();
        saturationShift.value = depress;
        colorAdjustments.saturation.SetValue(saturationShift);
    }
}
