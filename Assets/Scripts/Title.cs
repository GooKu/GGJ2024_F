using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Title : MonoBehaviour
{
    [SerializeField] private Sprite defaultTitleSprite;
    [SerializeField] private Sprite goodEndTitleSprite;

    private void Start()
    {
        GetComponent<Image>().sprite = GameManger.Instance.GoodEnd ? goodEndTitleSprite : defaultTitleSprite;
    }
}
