using System.Collections.Generic;

public class Wallet
{
    public readonly Dictionary<TypeCurrency, int> _balances = new();

    public Wallet()
    {
        _balances.Add(TypeCurrency.Coin, 0);
        _balances.Add(TypeCurrency.Gem, 0);
        _balances.Add(TypeCurrency.Energy, 0);
    }

    public void Add(TypeCurrency typeCurrency, int amount)
    {
        if(amount <= 0)
            return;

        int currentBalance = GetBalance(typeCurrency);
        currentBalance += amount;

        _balances[typeCurrency] = currentBalance;
    }

    public void Spend(TypeCurrency typeCurrency, int amount)
    {
        if (amount <= 0)
            return;

        int currentBalance = GetBalance(typeCurrency);

        if(currentBalance <= 0)
            return;

        currentBalance -= amount;

        _balances[typeCurrency] = currentBalance;
    }

    public int GetBalance(TypeCurrency typeCurrency)
    {
        if(_balances.TryGetValue(typeCurrency, out int balance))
            return balance;

        return 0;
    }
}
