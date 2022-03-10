using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace DebtBook.Models;

public class Debtor : BindableBase
{
    private string _name;
    private double _balance;
    private ObservableCollection<Transaction> _history;

    public Debtor()
    {
        
    }
        
    public Debtor(string name, double balance, ObservableCollection<Transaction> history)
    {
        _name = name;
        _balance = balance;
        _history = new ObservableCollection<Transaction>(history);
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

    public ObservableCollection<Transaction> History
    {
        get => _history;
        set { SetProperty(ref _history, value); }
    }
    
    public Debtor Clone()
    {
        return this.MemberwiseClone() as Debtor;
    }

}