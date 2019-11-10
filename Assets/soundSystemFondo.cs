using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundSystemFondo : MonoBehaviour
{
    public static soundSystemFondo instance;
    public AudioClip audioClipFondo;
    
    public AudioSource audioSource;

    private void Awake()
    {
        if (soundSystemFondo.instance == null)
        {
            soundSystemFondo.instance = this;
        }
        else if (soundSystemFondo.instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic()
    {
        audioSource.clip = audioClipFondo;
        audioSource.Play();
    }

    private void OnDestroy()
    {
        soundSystemFondo.instance = null;
    }
}
