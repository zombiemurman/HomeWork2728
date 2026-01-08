using System.Collections.Generic;
using UnityEngine;

public class EnemyList
{

    private List<Enemy> _enemyList = new List<Enemy>();

    public List<Enemy> List => _enemyList;

    public void AddEnemy(TypeDie typeDie, MonoBehaviour coroutineRunner = null, float secondsLife = 0)
    {
        string name = "Enemy_" + _enemyList.Count + "_" + typeDie;

        Enemy enemy = new Enemy(name, typeDie, coroutineRunner, secondsLife);
        _enemyList.Add(enemy);
    }

    public int Count => _enemyList.Count;

    public void ShowEnemy()
    {
        foreach (Enemy enemy in _enemyList)
            Debug.Log(enemy.Name);
    }

    public void EnemyDestroyTo(EnemyFilter enemyFilter)
    {
        if (enemyFilter == null)
            Debug.LogError("enemyFilter = null");

        for (int i = _enemyList.Count - 1; i >= 0; i--)
        {
            if (enemyFilter.Invoke(_enemyList[i]))
            {
                _enemyList.RemoveAt(i);
            }
        }
    }

    public void EnemyDestroyMaxCount(EnemyMaxFilter enemyMaxFilter)
    {
        while(enemyMaxFilter.Invoke(_enemyList.Count))
        {
            _enemyList.RemoveAt(_enemyList.Count -1);
        }
    }

}
