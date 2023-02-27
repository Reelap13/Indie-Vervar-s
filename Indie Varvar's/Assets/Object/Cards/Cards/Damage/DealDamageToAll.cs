using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToAll : Card, IPlayableCard
{
    [SerializeField] int _startDamage;
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
        List<EnemyCash> enemyList = CardGameController.Instance.EnemyBoard.EnemyList;
        int n = enemyList.Count;
        int i = 0;
        while (i < n)
        {
            enemyList[i].Enemy.takeDamage(_damage + CardGameController.Instance.Player.Strength);
            while (n > enemyList.Count)
            {
                --n;
                --i;
            }
            ++i;
        }
    }
}
