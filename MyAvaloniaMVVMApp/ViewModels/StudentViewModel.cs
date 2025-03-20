using ReactiveUI;
using MyAvaloniaMVVMApp.Models;
using System.Collections.Generic;

namespace MyAvaloniaMVVMApp.ViewModels
{
    public class StudentViewModel : ViewModelBase
    {
        private readonly Student _student;

        public string FullName => $"{_student.FirstName ?? "Unknown"} {_student.LastName ?? "Unknown"}";
        public List<string> EnrolledSubjects => _student.EnrolledSubjects ?? new List<string>();

        public StudentViewModel(Student student)
        {
            _student = student ?? new Student(); // Zapobiega null reference exception
        }
    }
}
