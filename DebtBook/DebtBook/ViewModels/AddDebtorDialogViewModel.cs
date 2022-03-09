using System;
using System.Windows;
using System.Windows.Input;
using DebtBook.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
// ReSharper disable ConstantNullCoalescingCondition

namespace DebtBook;

public class AddDebtorDialogViewModel : BindableBase
{
    public AddDebtorDialogViewModel(Debtor debtor)
    {
        CurrentDebtor = debtor;
    }

    #region Properties
    
    private Debtor currentDebtor;
    public Debtor CurrentDebtor
    {
        get => currentDebtor;
        set { SetProperty(ref currentDebtor, value); }
    }
    
    #endregion
    
    #region Commands
    private ICommand saveCommand;
    public ICommand SaveCommand
    {
        get
        {
            return saveCommand ??= new DelegateCommand(
                    () => { }, () => IsValid)
                .ObservesProperty(() => CurrentDebtor.Name)
                .ObservesProperty(() => CurrentDebtor.Balance);
        }
    }
    
    public bool IsValid
    {
        get
        {
            if (string.IsNullOrWhiteSpace(CurrentDebtor.Name) || CurrentDebtor.Balance == null)
                return false;
            return true;
        }
    }

    #endregion
}