using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerSaver : MonoBehaviour
{
    [SerializeField] private int startHP;

    private const string PATH = "PlayerInfo";

    public void SetStartHP()
    {
        SaveHP(startHP);
    }

    public void SaveHP(int HP)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(PATH, FileMode.Create);

        PlayerInfo player = new PlayerInfo(HP);

        bf.Serialize(fs, player);

        fs.Close();
    }

    public int LoadHP()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(PATH, FileMode.Open);

        PlayerInfo player = (PlayerInfo)bf.Deserialize(fs);

        fs.Close();

        return player.HP;
    }

}

[Serializable]
class PlayerInfo
{
    private int _healthPoint;
    
    public PlayerInfo(int HP)
    {
        _healthPoint = HP;
    }

    public int HP
    {
        set
        {
            _healthPoint = value;
        }
        get
        {
            return _healthPoint;
        }
    }
}