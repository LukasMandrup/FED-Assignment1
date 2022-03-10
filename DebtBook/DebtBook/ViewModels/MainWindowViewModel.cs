using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using DebtBook.Data;
using DebtBook.Models;
using DebtBook.Views;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
// ReSharper disable ConstantNullCoalescingCondition

namespace DebtBook;

public class MainWindowViewModel : BindableBase
{
    private string filePath = "";
    private string fileName = Repository.DebtorsPath;


    public MainWindowViewModel()
    {
        Debtors ??= Repository.ReadFile(Repository.DebtorsPath);
        if (Debtors == null)
            Debtors = new ObservableCollection<Debtor>();
        
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
                Repository.SaveFile(Path.Combine(filePath, fileName), Debtors);
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
                Repository.SaveFile(Path.Combine(filePath, fileName), Debtors);
            }, () => CurrentIndex >= 0)
            .ObservesProperty(() => Debtors)
            .ObservesProperty(() => CurrentDebtor);
    
    private DelegateCommand _SaveAsCommand;
    public DelegateCommand SaveAsCommand
    {
        get { return _SaveAsCommand ?? (_SaveAsCommand = new DelegateCommand(SaveAsCommand_Execute)); }
    }

    private void SaveAsCommand_Execute()
    {

        var dialog = new SaveFileDialog
        {
            Filter = "Agent assignment documents|*.agn|All Files|*.*",
            DefaultExt = "agn"
        };
        
        if (filePath == "")
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        else
            dialog.InitialDirectory = Path.GetDirectoryName(filePath);

        if (dialog.ShowDialog(App.Current.MainWindow) == true)
        {
            filePath = dialog.FileName;
            fileName = Path.GetFileName(filePath);
            Repository.SaveFile(Path.Combine(filePath, fileName), Debtors);
        }
    }
    
    
    DelegateCommand _OpenFileCommand;
    public DelegateCommand OpenFileCommand
    {
        get { return _OpenFileCommand ?? (_OpenFileCommand = new DelegateCommand(OpenFileCommand_Execute)); }
    }

    private void OpenFileCommand_Execute()
    {
        var dialog = new OpenFileDialog
        {
            Filter = "Agent assignment documents|*.agn|All Files|*.*",
            DefaultExt = "agn"
        };
        if (filePath == "")
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        else
            dialog.InitialDirectory = Path.GetDirectoryName(filePath);

        if (dialog.ShowDialog(App.Current.MainWindow) == true)
        {
            filePath = dialog.FileName;
            fileName = Path.GetFileName(filePath);
            try
            {
                Debtors = Repository.ReadFile(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}





















