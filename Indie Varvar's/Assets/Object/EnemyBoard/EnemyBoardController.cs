using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoardController : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPref;
    private List<EnemyCash> _enemies = new List<EnemyCash>();
    private const int MAX_NUMBER_OF_ENEMY = 5;

    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    public void AddEnemy(GameObject enemyPref)
    {
        GameObject newEnemy = Instantiate(enemyPref) as GameObject;
        EnemyCash enemyCash = new EnemyCash(newEnemy);

        enemyCash.Transform.parent = _transform;
        Vector3 Shift = new Vector3(enemyCash.Renderer.bounds.size.x, 0, 0);


    }
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
        public GameObject EnemyObject;
        public Transform Transform;
        public Enemy Enemy;
        public Renderer Renderer;

        public EnemyCash(GameObject enemy)
        {
            this.EnemyObject = enemy;
            Transform = enemy.GetComponent<Transform>();
            Enemy = enemy.GetComponent<Enemy>();
            Renderer = enemy.GetComponent<Renderer>();
        }
    }
}
