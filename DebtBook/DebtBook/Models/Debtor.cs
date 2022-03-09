using System.Collections.Generic;
using Prism.Mvvm;

namespace DebtBook.Models;

public class Debtor : BindableBase
{
    private string _name;
    private double _balance;
    private List<Transaction> _history;

    public Debtor()
    {
        
    }
        
    public Debtor(string name, double balance, List<Transaction> history)
    {
        _name = name;
        _balance = balance;
        _history = new List<Transaction>(history);
    }

    public void AddTransaction(Transaction transaction)
    {
        _balance += transaction.Amount;
        _history.Add(transaction);
    }

    public string Name
    {
        get => _name;
        set { SetProperty(ref _name, value); }
    }

    public double Balance
    {
        get => _balance;
        set { SetProperty(ref _balance, value); }
    }

    public List<Transaction> History
    {
        get => _history;
        set { SetProperty(ref _history, value); }
    }
    
    public Debtor Clone()
    {
        return this.MemberwiseClone() as Debtor;
    }

}