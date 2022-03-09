using System;

namespace DebtBook.Models;

public class Transaction
{
    private DateTime _dateTime;
    private double _amount;

    public Transaction(DateTime dateTime, double amount)
    {
        _dateTime = dateTime;
        _amount = amount;
    }

    public DateTime DateTime { get; set; }
    public double Amount { get; set; }
}