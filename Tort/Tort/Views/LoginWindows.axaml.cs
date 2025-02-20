using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Tort.ViewModels;


namespace Tort;

public partial class LoginWindows : Window
{
    public LoginWindows()
    {
        InitializeComponent();
        Button closeButton = this.FindControl<Button>("CloseButton");

        if (closeButton != null)
        {
            closeButton.Click += CloseButton_Click; ;
        }


        DataContext = new LoginViewModel();
    }
     private void CloseButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }
}