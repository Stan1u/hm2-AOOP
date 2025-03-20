using Avalonia.Controls;
using MyAvaloniaMVVMApp.ViewModels;

namespace MyAvaloniaMVVMApp.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
    }
}