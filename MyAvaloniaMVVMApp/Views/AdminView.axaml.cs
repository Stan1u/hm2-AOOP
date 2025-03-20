using Avalonia.Controls;
using MyAvaloniaMVVMApp.Models;
using MyAvaloniaMVVMApp.ViewModels;

namespace MyAvaloniaMVVMApp.Views
{
    public partial class AdminView : Window
    {
        public AdminView()
        {
            InitializeComponent();
        }

        public AdminView(People people) : this()
        {
            DataContext = new AdminViewModel(people);
        }
    }
}
