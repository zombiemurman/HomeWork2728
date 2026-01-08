using System;
using UnityEngine;

public class Example : MonoBehaviour
{
    public event Action<EnemyList> EnemyUpdated;

    private EnemyList _enemyList = new EnemyList();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _enemyList.AddEnemy(TypeDie.Die);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _enemyList.AddEnemy(TypeDie.Time, this, 5);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _enemyList.EnemyDestroyTo(enemy => enemy.TypeDie == TypeDie.Die);
        }

        _enemyList.EnemyDestroyTo(enemy => enemy.TypeDie == TypeDie.Time && enemy.CurrentTime <= 0);

        _enemyList.EnemyDestroyMaxCount(count => count > 10);

        EnemyUpdated?.Invoke(_enemyList);
    }
}
