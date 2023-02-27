using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : Card, IPlayableCard
{
    [SerializeField] int _startDamage;
    [SerializeField] int _hitCount;
    int _damage;
    private void Awake()
    {
        _damage = _startDamage + CardGameController.Instance.Player.Strength;
        CardGameController.Instance.Player.ChangingStrenghtEvent.AddListener(ChangeStrength);

    }
    void ChangeStrength(int value)
    {
        _damage += value;
    }
    public void OnPlay()
    {
        for (int i = 0; i < _hitCount; i++)
            CardGameController.Instance.EnemyBoard.DealDamageToFirstEnemy(_damage + CardGameController.Instance.Player.Strength);
    }
}
