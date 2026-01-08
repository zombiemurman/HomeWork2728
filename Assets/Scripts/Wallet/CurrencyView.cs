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

    public void Initialize(TypeCurrency typeCurrency, Sprite sprite)
    {
        _typeCurrency = typeCurrency;

        _imageCurrency.sprite = sprite;

        _valueCurrency = 1;
    }

    public void UpdateText(int amount)
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
