using System.Collections.Generic;

public class Wallet
{
    public readonly Dictionary<TypeCurrency, ReactiveVariable<int>> _balances = new();

    private ReactiveVariable<int> _currentBalanceCoin;
    private ReactiveVariable<int> _currentBalanceGem;
    private ReactiveVariable<int> _currentBalanceEnergy;

    public Wallet()
    {
        _currentBalanceCoin = new ReactiveVariable<int>(0);
        _currentBalanceGem = new ReactiveVariable<int>(0);
        _currentBalanceEnergy = new ReactiveVariable<int>(0);

        _balances.Add(TypeCurrency.Coin, _currentBalanceCoin);
        _balances.Add(TypeCurrency.Gem, _currentBalanceGem);
        _balances.Add(TypeCurrency.Energy, _currentBalanceEnergy);
    }

    public void Add(TypeCurrency typeCurrency, int amount)
    {
        if(amount <= 0)
            return;

        ReactiveVariable<int> currentBalance = GetBalance(typeCurrency);
        currentBalance.Value += amount;

        _balances[typeCurrency] = currentBalance;
    }

    public void Spend(TypeCurrency typeCurrency, int amount)
    {
        if (amount <= 0)
            return;

        ReactiveVariable<int> currentBalance = GetBalance(typeCurrency);

        if(currentBalance.Value <= 0)
            return;

        currentBalance.Value -= amount;

        _balances[typeCurrency] = currentBalance;
    }

    public ReactiveVariable<int> GetBalance(TypeCurrency typeCurrency)
    {
        if(_balances.TryGetValue(typeCurrency, out ReactiveVariable<int> balance))
            return balance;

        return null;
    }
}
