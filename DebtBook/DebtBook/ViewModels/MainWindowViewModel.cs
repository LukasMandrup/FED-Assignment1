using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using DebtBook.Data;
using DebtBook.Models;
using DebtBook.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
// ReSharper disable ConstantNullCoalescingCondition

namespace DebtBook;

public class MainWindowViewModel : BindableBase
{
    public MainWindowViewModel() => Debtors = Repository.ReadFile();


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
                Repository.SaveFile(Debtors);
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
                    Debtors[CurrentIndex] = tempDebtor;
                    CurrentDebtor = tempDebtor;
                }
                Repository.SaveFile(Debtors);
            }, () => CurrentIndex >= 0)
            .ObservesProperty(() => Debtors)
            .ObservesProperty(() => CurrentDebtor);
}





















