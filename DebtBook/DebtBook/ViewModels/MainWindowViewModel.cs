using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using DebtBook.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace DebtBook;

public class MainWindowViewModel : BindableBase
{
    
    public MainWindowViewModel(IDialogService dialogService)
    {
        _dialogService = dialogService;

        Debtors = new ObservableCollection<Debtor>();
        
        Debtors.Add(new Debtor("Alice", -100.0, new List<Transaction>()));
        Debtors.Add(new Debtor("Bob", 200.0, new List<Transaction>()));
        Debtors.Add(new Debtor("Carol", 60.0, new List<Transaction>()));
        Debtors.Add(new Debtor("Don", -1024.0, new List<Transaction>()));
    }
    
    private IDialogService _dialogService;
    
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
                var tempDebtor = new Debtor();
                ((App) Application.Current).Debtor = tempDebtor;
                _dialogService.ShowDialog("AddNewDebtorDialog", null, result =>
                {
                    if (result.Result == ButtonResult.OK)
                    {
                        Debtors.Add(((App)Application.Current).Debtor);
                    }
                });
            });
    
}





















