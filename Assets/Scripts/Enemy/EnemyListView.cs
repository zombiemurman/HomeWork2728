using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyListView : MonoBehaviour
{
    [SerializeField] private Example _example;
    [SerializeField] private TMP_Text _textPrefab;
    [SerializeField] private RectTransform _layoutGroup;

    private List<TMP_Text> EnemyTextView = new List<TMP_Text>();

    private void Start()
    {
        _example.EnemyUpdated += OnUpdateLayout;
    }

    private void OnDestroy()
    {
        _example.EnemyUpdated -= OnUpdateLayout;
    }

    private void OnUpdateLayout(EnemyList enemyList)
    {
        DestroyHearts();
        CreateHearts(enemyList);
    }

    private void DestroyHearts()
    {
        while (EnemyTextView.Count > 0)
        {
            Destroy(EnemyTextView[EnemyTextView.Count - 1].gameObject);
            EnemyTextView.RemoveAt(EnemyTextView.Count - 1);
        }
    }

    private void CreateHearts(EnemyList enemyList)
    {
        foreach (Enemy enemy in enemyList.List)
        {
            TMP_Text enemyName = Instantiate(_textPrefab, _layoutGroup);
            enemyName.text = enemy.Name;

            EnemyTextView.Add(enemyName);
        }
    }
}
