using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Loader : MonoBehaviour
{
    [SerializeField] AudioMixerGroup mixer;
    void Start()
    {
        Screen.SetResolution(Option.GameScreen.Resolution.width, Option.GameScreen.Resolution.height, Option.GameScreen.IsFullScreen);
        QualitySettings.SetQualityLevel(Option.Quality.QualityIndex);

        mixer.audioMixer.SetFloat("MusicVolume", Option.Audio.MusicsVolume);
        mixer.audioMixer.SetFloat("SoundVolume", Option.Audio.SoundsVolume);
    }
}
