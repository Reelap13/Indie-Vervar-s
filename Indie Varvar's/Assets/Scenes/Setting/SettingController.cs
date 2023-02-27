using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;

public class SettingController : MonoBehaviour
{
    [SerializeField] TMP_Dropdown resolutionDropdown;
    [SerializeField] TMP_Dropdown qualityDropdown;
    [SerializeField] Toggle fullScreenToggle;

    [SerializeField] AudioMixerGroup mixer;
    [SerializeField] Slider musicsSlider;
    [SerializeField] Slider soundsSlider;

    Resolution[] resolutions;

    void Start()
    {
        compilationOfResolutionDropdown();
        LoadSetting();
    }

    void compilationOfResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; ++i)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();

    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetMusicsVolume(float volume)
    {
        mixer.audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSoundsVolume(float volume)
    {
        mixer.audioMixer.SetFloat("SoundVolume", volume);
    }


    public void ExitSetting()
    {
        ReturnSetting();
        SceneManager.LoadScene(0);
    }

    public void SaveSetting()
    {
        Option.GameScreen.ResolutionIndex = resolutionDropdown.value;
        Option.Quality.QualityIndex = qualityDropdown.value;
        Option.GameScreen.IsFullScreen = fullScreenToggle.isOn;

        float value;
        mixer.audioMixer.GetFloat("MusicVolume", out value);
        Option.Audio.MusicsVolume = value;

        mixer.audioMixer.GetFloat("SoundVolume", out value);
        Option.Audio.SoundsVolume = value;

        ExitSetting();
    }

    public void LoadSetting()
    {
        resolutionDropdown.value = Option.GameScreen.ResolutionIndex;
        qualityDropdown.value = Option.Quality.QualityIndex;
        fullScreenToggle.isOn = Option.GameScreen.IsFullScreen;

        musicsSlider.value = Option.Audio.MusicsVolume;
        soundsSlider.value = Option.Audio.SoundsVolume;
    }

    public void ReturnSetting()
    {
        Screen.SetResolution(Option.GameScreen.Resolution.width, Option.GameScreen.Resolution.height, Option.GameScreen.IsFullScreen);
        QualitySettings.SetQualityLevel(Option.Quality.QualityIndex);

        mixer.audioMixer.SetFloat("MusicVolume", Option.Audio.MusicsVolume);
        mixer.audioMixer.SetFloat("SoundVolume", Option.Audio.SoundsVolume);
    }
}
