using System.Windows;

namespace DebtBook.Views;

public partial class AddDebtorDialog : Window
{
    public AddDebtorDialog()
    {
        InitializeComponent();
    }

    private void btnOk_Click(object sender, RoutedEventArgs e)
    {
        var vm = DataContext as AddDebtorDialogViewModel;
        if (vm.IsValid)
            DialogResult = true;
        else
            MessageBox.Show("Enter values for name and initial value", "Missing values");
    }
}