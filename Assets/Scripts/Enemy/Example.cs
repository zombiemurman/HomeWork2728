using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Example : MonoBehaviour
{
    private Dictionary<Enemy, Func<bool>> _enemies = new();
    private List<Enemy> _enemiesRemove = new();

    private int _count = 0;

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Enemy enemy = new Enemy(Time.time, "Enemy_" + _count.ToString());
            
            _enemies.Add(enemy, () => Input.GetKeyDown(KeyCode.F) || _enemies.Count > 10);
            
            _count++;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Enemy enemy = new Enemy(Time.time, "Enemy_" + _count.ToString());
            
            _enemies.Add(enemy, () => Time.time - enemy.CreateTime >= 5 || _enemies.Count > 10);

            _count++;
        }

        foreach(var enemyValue in _enemies)
        {
            Debug.Log(enemyValue.Key.Name);
        }

        _enemiesRemove.Clear();

        foreach (var enemyValue in _enemies)
        {
            if (enemyValue.Value())
            {
                _enemiesRemove.Add(enemyValue.Key);
                break;
            }       
        }

        foreach (var enemyValue in _enemiesRemove)
            _enemies.Remove(enemyValue);
    }
}
