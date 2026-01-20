using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class WalletView : MonoBehaviour
{
    private Wallet _wallet;

    [SerializeField] private CurrencyView _buttonPrefab;
    
    [SerializeField] private RectTransform _listContainer;

    [SerializeField] private Sprite[] _sprites = new Sprite[3];

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;

        foreach (var currency in _wallet._balances)
        {
            CurrencyView currencyView = Instantiate(_buttonPrefab, _listContainer);
            //currencyView.UpdateText(currency.Value.Value);

            currencyView.Initialize(currency.Key, _sprites[(int)currency.Key], currency.Value);
            currencyView.CurrencyChanged += OnCurrencyButtonClick;
        }
    }

    public void OnCurrencyButtonClick(CurrencyView currency, TypeCurrency typeCurrency, TypeCurrencyChanged typeCurrencyChanged, int amount)
    {
        switch (typeCurrencyChanged)
        {
            case TypeCurrencyChanged.Add:
                _wallet.Add(typeCurrency, amount);
                break;

            case TypeCurrencyChanged.Spend:
                _wallet.Spend(typeCurrency, amount);
                break;

            default:
                break;
        }

        //currency.UpdateText(_wallet.GetBalance(typeCurrency).Value);
    }

}
