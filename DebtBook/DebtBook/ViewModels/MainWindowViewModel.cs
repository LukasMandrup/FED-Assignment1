using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using DebtBook.Models;
using DebtBook.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
// ReSharper disable ConstantNullCoalescingCondition

namespace DebtBook;

public class MainWindowViewModel : BindableBase
{
    public MainWindowViewModel()
    {
        Debtors = new ObservableCollection<Debtor>();
        
        Debtors.Add(new Debtor("Alice", -100.0, new List<Transaction> { new (DateTime.UnixEpoch, 105)}));
        Debtors.Add(new Debtor("Bob", 200.0, new List<Transaction>()));
        Debtors.Add(new Debtor("Carol", 60.0, new List<Transaction>()));
        Debtors.Add(new Debtor("Don", -1024.0, new List<Transaction>()));
    }
    
    
    private ObservableCollection<Debtor> debtors;
    public ObservableCollection<Debtor> Debtors
    {
        get => debtors;
        set => SetProperty(ref debtors, value);
    }
    
    private Debtor currentDebtor;
    public Debtor CurrentDebtor
    {
        get => currentDebtor; 
        set => SetProperty(ref currentDebtor, value);
    }
    
    private int currentIndex;
    public int CurrentIndex
    {
        get { return currentIndex; }
        set { SetProperty(ref currentIndex, value); }
    }

    private DelegateCommand showAddDebtorDialogCommand;
    public DelegateCommand ShowAddDebtorDialogCommand =>
        showAddDebtorDialogCommand ??= new DelegateCommand(
            () =>
            {
                var newDebtor = new Debtor();
                var vm = new AddDebtorDialogViewModel(newDebtor);

                var dlg = new AddDebtorDialog
                {
                    DataContext = vm
                };

                if (dlg.ShowDialog() == true)
                {
                    Debtors.Add(newDebtor);
                    CurrentDebtor = newDebtor;
                }
            });

    private DelegateCommand editHistory;

    public DelegateCommand EditHistory =>
        editHistory ??= new DelegateCommand(
            () =>
            {
                var tempDebtor = CurrentDebtor.Clone();
                var vm = new TransactionsViewModel(tempDebtor);

                var dlg = new TransactionsDialog
                {
                    DataContext = vm,
                    Owner = Application.Current.MainWindow
                };

                if (dlg.ShowDialog() == true)
                {
                    CurrentDebtor.History = tempDebtor.History;
                }
            }, () => CurrentIndex >= 0).ObservesProperty(() => CurrentIndex);
}





















