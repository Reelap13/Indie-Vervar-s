using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fox : Enemy
{

    [SerializeField] TextMeshPro _pushTextMesh;
    [SerializeField] private int _push;

    private new void Awake()
    {
        base.Awake();
        CardGameController.EnemyTurnEvent.AddListener(attack);
        _pushTextMesh.text = _push + "P";
    }
    public void attack()
    {
        CardGameController.Instance.Player.Move(-_push);
    }
}
