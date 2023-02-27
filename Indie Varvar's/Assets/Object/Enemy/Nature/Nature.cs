using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Nature : MonoBehaviour
{
    [SerializeField] List<NatuerMove> _moves;
    [SerializeField] TextMeshProUGUI _textMeshPro;
    NatuerMove _nextMove;

    private void Awake()
    {
        _nextMove = _moves[Random.Range(0, _moves.Count)];
        _textMeshPro.text = _nextMove.Description;
        CardGameController.AfterEnemyTurnEvent.AddListener(MakeMove);
        
    }
    public void MakeMove()
    {
        _nextMove.DoMove();
        _nextMove = _moves[Random.Range(0, _moves.Count)];
        _textMeshPro.text = _nextMove.Description;
    }
}
