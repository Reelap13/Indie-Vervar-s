using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : Singleton<MusicController>
{
    AudioSource audio;
    private void Awake()
    {
        if (Instance != gameObject.GetComponent<MusicController>() && Instance != null)
        {
            Destroy(gameObject);
        }
        audio = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
}
