using Avalonia.Controls;
using MyAvaloniaMVVMApp.ViewModels;
using MyAvaloniaMVVMApp.Models;
namespace MyAvaloniaMVVMApp.Views
{
    public partial class TeacherView : Window
    {
        public TeacherView()
        {
            InitializeComponent();
        }

        public TeacherView(Teacher teacher) : this()
        {
            DataContext = new TeacherViewModel(teacher);
        }
    }
}