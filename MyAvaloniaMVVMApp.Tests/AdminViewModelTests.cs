using System.Collections.Generic;
using MyAvaloniaMVVMApp.Models;
using MyAvaloniaMVVMApp.ViewModels;
using Xunit;

namespace MyAvaloniaMVVMApp.Tests
{
    public class AdminViewModelTests
    {
        private readonly AdminViewModel _adminViewModel;

        public AdminViewModelTests()
        {
            var people = new People
            {
                Teachers = new List<Teacher>
                {
                    new Teacher { Id = 1, FirstName = "John", LastName = "Doe" }
                },
                Students = new List<Student>
                {
                    new Student { Id = 1, FirstName = "Jane", LastName = "Doe" }
                }
            };
            _adminViewModel = new AdminViewModel(people);
        }

        [Fact]
        public void AdminViewModel_InitializesWithPeople()
        {
            // Assert
            Assert.NotNull(_adminViewModel);
            Assert.NotEmpty(_adminViewModel.Teachers);
            Assert.NotEmpty(_adminViewModel.Students);
        }
    }
}
