using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoardController : MonoBehaviour
{
    private List<EnemyCash> _enemies = new List<EnemyCash>();
    private const int MAX_NUMBER_OF_ENEMY = 5;

    private Transform _transform;

    private const float INDENT = 1.1f;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    public void AddEnemy(GameObject enemyPref)
    {
        if (_enemies.Count >= MAX_NUMBER_OF_ENEMY)
            return;

        GameObject newEnemy = Instantiate(enemyPref) as GameObject;
        EnemyCash enemyCash = new EnemyCash(newEnemy);

        enemyCash.Transform.parent = _transform;
        Vector3 shift = new Vector3(enemyCash.Renderer.bounds.size.x * _enemies.Count, 0, 0) * INDENT;
        enemyCash.Transform.position = _transform.position + shift;
 
        _enemies.Add(enemyCash);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        foreach(EnemyCash enemyCash in _enemies)
        {
            if (enemyCash.Enemy.Equals(enemy))
            {
                _enemies.Remove(enemyCash);
                break;
            }
        }

        MoveEnemies();
    }

    private void MoveEnemies()
    {
        for (int i = 0; i < _enemies.Count; ++i)
        {
            EnemyCash enemyCash = _enemies[i];
            Vector3 shift = new Vector3(enemyCash.Renderer.bounds.size.x * i, 0, 0) * INDENT;
            enemyCash.Enemy.MoveToPosition(_transform.position + shift);
        }
    }
}

struct EnemyCash
{
    public GameObject EnemyObject;
    public Transform Transform;
    public Enemy Enemy;
    public Renderer Renderer;

    public EnemyCash(GameObject enemy)
    {
        EnemyObject = enemy;
        Transform = enemy.GetComponent<Transform>();
        Enemy = enemy.GetComponent<Enemy>();
        Renderer = enemy.GetComponent<Renderer>();
    }
}