using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nature : MonoBehaviour
{
    [SerializeField] List<NatuerMove> _moves;
    NatuerMove _nextMove;

    private void Awake()
    {
        _nextMove = _moves[Random.Range(0, _moves.Count)];
        CardGameController.AfterEnemyTurnEvent.AddListener(MakeMove);

    }
    public void MakeMove()
    {
        _nextMove.DoMove();
        _nextMove = _moves[Random.Range(0, _moves.Count)];
    }
}
