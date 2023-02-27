using UnityEngine;

public class Quality
{
    static int qualityIndex = 3;

    static Quality()
    {
        if (PlayerPrefs.HasKey("QualityIndex"))
        {
            qualityIndex = PlayerPrefs.GetInt("QualityIndex");
        }
    }

    public int QualityIndex
    {
        set
        {
            qualityIndex = value;
            PlayerPrefs.SetInt("QualityIndex", qualityIndex);
        }
        get
        {
            return qualityIndex;
        }
    }
}
