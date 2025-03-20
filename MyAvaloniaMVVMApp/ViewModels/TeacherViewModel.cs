using ReactiveUI;
using MyAvaloniaMVVMApp.Models;

namespace MyAvaloniaMVVMApp.ViewModels
{
    public class TeacherViewModel : ViewModelBase
    {
        private readonly Teacher _teacher;

        public string FullName => $"{_teacher.FirstName ?? "Unknown"} {_teacher.LastName ?? "Unknown"}";
        public string Subject => _teacher.Subject ?? "No Subject Assigned";

        public TeacherViewModel(Teacher teacher)
        {
            _teacher = teacher ?? new Teacher(); // Zapobiega null reference exception
        }
    }
}
