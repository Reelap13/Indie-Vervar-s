using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoardController : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPref;
    private List<EnemyCash> _enemies = new List<EnemyCash>();
    private const int MAX_NUMBER_OF_ENEMY = 5;

    private void Start()
    {
        
    }
    /*public void AddEnemy(GameObject enemyPref)
    {
        EnemyCash enemyCash = new EnemyCash();
        eenemy = Instantiate(enemyPref) as GameObject;
        newEnemyTr = enemy.GetComponent<Transform>();
        newEnemyEn = newEnemy.GetComponent<Enemy>();
        _enemies.Add(enemy);
        
    }*/
    /*private IEnumerator AddEnemyEveryFivSec()
    {
        int k = 0;
        while (k < 10)
        { 
            AddEnemy(newEnemy);
            yield return new WaitForSeconds(5);
        }
    }*/


    struct EnemyCash
    {
        GameObject enemy;
        Transform tr;
        Enemy en;

        EnemyCash(GameObject enemy)
        {
            this.enemy = enemy;
            tr = enemy.GetComponent<Transform>();
            en = enemy.GetComponent<Enemy>();
        }

    }
}
