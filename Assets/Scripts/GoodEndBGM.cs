using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodEndBGM : MonoBehaviour
{
    public AudioClip backgroundMusic;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
