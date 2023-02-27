using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class FigurSaver : MonoBehaviour
{
    private const string PATH = "FIGUR";

    public void SetStartValue()
    {
        File.Delete(PATH);
    }

    public void FigureSaver(PointCash pointCash)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(PATH, FileMode.Create);

        FigurSave figur = new FigurSave(pointCash);

        bf.Serialize(fs, figur);

        fs.Close();
    }

    public FigurSave LoadFigur()
    {
        if (!File.Exists(PATH))
        {
            return new FigurSave(MapController.Instance.GetFirstPointer());
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(PATH, FileMode.Open);

        FigurSave figur = (FigurSave)bf.Deserialize(fs);

        fs.Close();

        return figur;
    }
}

[Serializable]
public class FigurSave
{
    PointCash _currentPointCash;
    bool isFight = true;

    public FigurSave(PointCash pointCash)
    {
        _currentPointCash = pointCash;
    }

    public PointCash GetPointCash()
    {
        return _currentPointCash;
    }

    public void SetPointCash(PointCash pointCash)
    {
        _currentPointCash = pointCash;
    }

    public bool IsFight
    {
        set
        {
            isFight = value;
        }
        get
        {
            return isFight;
        }
    }

}