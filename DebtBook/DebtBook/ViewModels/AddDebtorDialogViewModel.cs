using System;
using System.Windows;
using DebtBook.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace DebtBook;

public class AddDebtorDialogViewModel : BindableBase, IDialogAware
{
    
    public bool CanCloseDialog()
    {
        return true;
    }

    public void OnDialogClosed()
    {
        throw new NotImplementedException();
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
        Debtor = ((App)Application.Current).Debtor;
    }
    
    public event Action<IDialogResult> RequestClose;

    public virtual void RaiseRequestClose(IDialogResult dialogResult)
    {
        RequestClose?.Invoke(dialogResult);
    }

    public string Title { get; }

    private Debtor debtor;
    public Debtor Debtor
    {
        get => debtor;
        set { SetProperty(ref debtor, value); }
    }

    private DelegateCommand saveCommand;
    public DelegateCommand SaveCommand =>
        saveCommand ??= new DelegateCommand<string>(
            (string param) =>
            {
                ButtonResult result = ButtonResult.None;
                if (param?.ToLower() == "true")
                {
                    result = ButtonResult.OK;
                    ((App) Application.Current).Debtor = Debtor;
                }
                else if (param?.ToLower() == "false")
                    result = ButtonResult.Cancel;
                
                RaiseRequestClose(new DialogResult(result));
            }, 
            () =>
                    
                )M

}