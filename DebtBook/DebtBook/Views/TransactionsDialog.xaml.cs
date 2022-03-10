using System.Windows;

namespace DebtBook.Views;

public partial class TransactionsDialog : Window
{
    public TransactionsDialog()
    {
        InitializeComponent();
    }
    
    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
}