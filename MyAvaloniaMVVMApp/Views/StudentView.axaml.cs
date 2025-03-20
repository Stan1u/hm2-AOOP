using Avalonia.Controls;
using MyAvaloniaMVVMApp.ViewModels;
using MyAvaloniaMVVMApp.Models;
namespace MyAvaloniaMVVMApp.Views
{
    public partial class StudentView : Window
    {
        public StudentView()
        {
            InitializeComponent();
        }

        public StudentView(Student student) : this()
        {
            DataContext = new StudentViewModel(student);
        }
    }
}