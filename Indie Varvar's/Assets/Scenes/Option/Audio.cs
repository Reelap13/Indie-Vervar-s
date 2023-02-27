using UnityEngine;

public class Audio
{
    static float musicsVolume = 0;
    static float soundsVolume = 0;

    static Audio()
    {
        if (PlayerPrefs.HasKey("MusicsVolume"))
        {
            musicsVolume = PlayerPrefs.GetFloat("MusicsVolume");
        }

        if (PlayerPrefs.HasKey("SoundsVolume"))
        {
            soundsVolume = PlayerPrefs.GetFloat("SoundsVolume");
        }
    }


    public  float MusicsVolume
    {
        set
        {
            musicsVolume = value;
            PlayerPrefs.SetFloat("MusicsVolume", musicsVolume);
        }
        get
        {
            return musicsVolume;
        }
    }
    public float SoundsVolume
    {
        set
        {
            soundsVolume = value;
            PlayerPrefs.SetFloat("SoundsVolume", soundsVolume);
        }
        get
        {
            return soundsVolume;
        }
    }
}
