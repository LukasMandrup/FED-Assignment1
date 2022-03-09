using System;
using Prism.Mvvm;

namespace DebtBook.Models;

public class Transaction : BindableBase
{
    private DateTime _dateTime;
    public DateTime DateTime
    {
        get => _dateTime;
        set => SetProperty(ref _dateTime, value);
    }
    
    private double _amount;
    public double Amount
    {
        get => _amount;
        set => SetProperty(ref _amount, value);
    }

    public Transaction(DateTime dateTime, double amount)
    {
        _dateTime = dateTime;
        _amount = amount;
    }
    
}