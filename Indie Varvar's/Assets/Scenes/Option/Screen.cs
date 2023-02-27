using System.Collections.Generic;
using UnityEngine;

public class GameScreen
{
    static Resolution[] resolutions = Screen.resolutions;
    static Resolution currentResolution;

    static float width = Screen.currentResolution.width;
    static float height = Screen.currentResolution.height;

    static int resolutionIndex = 3;

    static bool isFullScreen = true;

    static GameScreen()
    {
        if (PlayerPrefs.HasKey("ScreenWidth"))
        {
            width = PlayerPrefs.GetFloat("ScreenWidth");
        }

        if (PlayerPrefs.HasKey("ScreenHeight"))
        {
            height = PlayerPrefs.GetFloat("ScreenHeight");
        }

        if (PlayerPrefs.HasKey("IsFullScreen"))
        {
            isFullScreen = (PlayerPrefs.GetInt("IsFullScreen") == 1);
        }

        FindCurrentResolutionAndResolutionIndex();
    }

    public Resolution Resolution
    {
        set
        {
            currentResolution = value;

            width = currentResolution.width;
            PlayerPrefs.SetFloat("ScreenWidth", width);

            height = currentResolution.height;
            PlayerPrefs.SetFloat("ScreenHeight", height);

            FindCurrentResolutionAndResolutionIndex();
        }
        get
        {
            
            return currentResolution;
        }
    }

    public int ResolutionIndex
    {
        set
        {
            resolutionIndex = value;
            currentResolution = resolutions[resolutionIndex];

            width = currentResolution.width;
            PlayerPrefs.SetFloat("ScreenWidth", width);

            height = currentResolution.height;
            PlayerPrefs.SetFloat("ScreenHeight", height);
        }
        get
        {

            return resolutionIndex;
        }
    }

    public bool IsFullScreen
    {
        set
        {
            isFullScreen = value;
            if (isFullScreen)
                PlayerPrefs.SetInt("IsFullScreen", 1);
            else
                PlayerPrefs.SetInt("IsFullScreen", 0);

        }
        get
        {
            return isFullScreen;
        }
    }


    static void FindCurrentResolutionAndResolutionIndex()
    {
        for (int i = 0; i < resolutions.Length; ++i)
        {
            if (width == resolutions[i].width && height == resolutions[i].height)
            {
                currentResolution = resolutions[i];
                resolutionIndex = i;
            }
        }
    }
}
