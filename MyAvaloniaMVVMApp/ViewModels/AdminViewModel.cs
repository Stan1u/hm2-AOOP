using ReactiveUI;
using MyAvaloniaMVVMApp.Models;
using System.Collections.Generic;

namespace MyAvaloniaMVVMApp.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {
        private People _people;

        public List<Teacher> Teachers => _people.Teachers ?? new List<Teacher>();
        public List<Student> Students => _people.Students ?? new List<Student>();

        public AdminViewModel(People people)
        {
            _people = people;
        }
    }
}
