using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DebtBook.Models;
using Prism.Commands;
using Prism.Mvvm;
// ReSharper disable ConstantNullCoalescingCondition

namespace DebtBook;

public class TransactionsViewModel : BindableBase
{
    public TransactionsViewModel(Debtor debtor)
    {
        CurrentDebtor = debtor;
        CurrentHistory = debtor.History;
    }
    
    private Debtor currentDebtor;
    public Debtor CurrentDebtor
    {
        get => currentDebtor;
        set => SetProperty(ref currentDebtor, value);
    }
    
    private ObservableCollection<Transaction> currentHistory;
    public ObservableCollection<Transaction> CurrentHistory
    {
        get => currentHistory;
        set => SetProperty(ref currentHistory, value);
    }
    
    private int currentIndex;
    public int CurrentIndex
    {
        get => currentIndex;
        set => SetProperty(ref currentIndex, value);
    }

    private double transactionAmount;
    public double TransactionAmount
    {
        get => transactionAmount;
        set => SetProperty(ref transactionAmount, value);
    }
    
    private ICommand addValueCommand;
    public ICommand AddValueCommand
    {
        get
        {
            return addValueCommand ??= new DelegateCommand(
                    () =>
                    {
                        CurrentHistory.Add(new Transaction(DateTime.Now, TransactionAmount));
                        TransactionAmount = 0;
                        //urrentDebtor.AddTransaction(new Transaction(DateTime.Now, TransactionAmount));
                    })
                .ObservesProperty(() => CurrentIndex)
                .ObservesProperty(() => TransactionAmount)
                .ObservesProperty(() => CurrentHistory)
                .ObservesProperty(() => CurrentDebtor);
        }
    }
    
    

}