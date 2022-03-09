using System.Collections.Generic;

namespace DebtBook.Models;

public class Debtor
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
        _history.Add(transaction);
    }
    
    public string Name { get => _name; set => _name = value; }
    public double Balance { get => _balance; set => _balance = value; }
    public List<Transaction> History { get => _history; set => _history = value; }

    public string Type { get; set; }
}