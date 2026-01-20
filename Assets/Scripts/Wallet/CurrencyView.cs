using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    public event Action<CurrencyView, TypeCurrency, TypeCurrencyChanged, int> CurrencyChanged;

    [SerializeField] private TMP_Text _text;
    
    [SerializeField] private Image _imageCurrency;

    private TypeCurrency _typeCurrency;

    private int _valueCurrency;

    private IReadOnlyVariable<int> _currentBalance;

    public void Initialize(TypeCurrency typeCurrency, Sprite sprite, IReadOnlyVariable<int> currentBalance)
    {
        _typeCurrency = typeCurrency;

        _currentBalance = currentBalance;
        _currentBalance.Changed += OnChangedBalance;

        _imageCurrency.sprite = sprite;

        _valueCurrency = 1;

        UpdateText(_currentBalance.Value);
    }

    private void OnChangedBalance(int arg1, int currentBalance)
    {
        UpdateText(currentBalance);
    }

    private void UpdateText(int amount)
    {
        _text.text = amount.ToString();
    }

    public void OnButtonAdd()
    {
        CurrencyChanged?.Invoke(this, _typeCurrency, TypeCurrencyChanged.Add, _valueCurrency);
    }

    public void OnButtonSpend()
    {
        CurrencyChanged?.Invoke(this, _typeCurrency, TypeCurrencyChanged.Spend, _valueCurrency);
    }
}
