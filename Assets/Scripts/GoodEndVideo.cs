using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoodEndVideo : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Image image5;
    public Image image6;
    public Image image7;
    public Image image8;
    public TextMeshProUGUI thankText;
    public Button QuitButton;
    public float imagesIntervals;
    void Start()
    {
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
        image4.gameObject.SetActive(false);
        image5.gameObject.SetActive(false);
        image6.gameObject.SetActive(false);
        image7.gameObject.SetActive(false);
        image8.gameObject.SetActive(false);
        thankText.enabled = false;
        QuitButton.gameObject.SetActive(false);

        StartCoroutine(AnimationStart());
    }

    IEnumerator AnimationStart()
    {
        image1.gameObject.SetActive(true);
        yield return new WaitForSeconds(imagesIntervals);
        image2.gameObject.SetActive(true);
        yield return new WaitForSeconds(imagesIntervals);
        image3.gameObject.SetActive(true);
        yield return new WaitForSeconds(imagesIntervals);
        image4.gameObject.SetActive(true);
        yield return new WaitForSeconds(imagesIntervals);
        image5.gameObject.SetActive(true);
        yield return new WaitForSeconds(imagesIntervals);
        image6.gameObject.SetActive(true);
        yield return new WaitForSeconds(imagesIntervals);
        image7.gameObject.SetActive(true);
        yield return new WaitForSeconds(imagesIntervals);
        image8.gameObject.SetActive(true);
        yield return new WaitForSeconds(imagesIntervals);
        thankText.enabled = true;
        QuitButton.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
