using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundSystem : MonoBehaviour
{
    public static soundSystem instance;
    public AudioClip audioClipCoin;
    public AudioClip audioClipShoot;
    
    public AudioSource audioSource;

    private void Awake()
    {
        if (soundSystem.instance == null)
        {
            soundSystem.instance = this;
        }
        else if (soundSystem.instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayCoin()
    {
        audioSource.clip = audioClipCoin;
        audioSource.Play();
    }

    public void PlayShoot()
    {
        audioSource.clip = audioClipShoot;
        audioSource.Play();
    }

    

    private void OnDestroy()
    {
        soundSystem.instance = null;
    }
}
