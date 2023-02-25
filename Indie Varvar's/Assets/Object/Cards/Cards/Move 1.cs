using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1 : Card, IPlayer
{
    public void OnPlay()
    {
        Debug.Log("Обращаюсь к герою");
    }
}
