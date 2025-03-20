using System.Collections.Generic;
using MyAvaloniaMVVMApp.Models;
using Xunit;

namespace MyAvaloniaMVVMApp.Tests
{
    public class UserModelTests
    {
        [Fact]
        public void Person_CanBeCreatedAndPropertiesSet()
        {
            // Arrange
            var person = new Person
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Login = "jdoe",
                Password = "password123"
            };

            // Assert
            Assert.Equal(1, person.Id);
            Assert.Equal("John", person.FirstName);
            Assert.Equal("Doe", person.LastName);
            Assert.Equal("jdoe", person.Login);
            Assert.Equal("password123", person.Password);
        }

        [Fact]
        public void Teacher_CanBeCreatedAndPropertiesSet()
        {
            // Arrange
            var teacher = new Teacher
            {
                Id = 1,
                FirstName = "Jane",
                LastName = "Doe",
                Subject = "Mathematics"
            };

            // Assert
            Assert.Equal(1, teacher.Id);
            Assert.Equal("Jane", teacher.FirstName);
            Assert.Equal("Doe", teacher.LastName);
            Assert.Equal("Mathematics", teacher.Subject);
        }

        [Fact]
        public void Student_CanBeCreatedAndPropertiesSet()
        {
            // Arrange
            var student = new Student
            {
                Id = 1,
                FirstName = "Jim",
                LastName = "Beam",
                EnrolledSubjects = new List<string> { "Math", "Science" }
            };

            // Assert
            Assert.Equal(1, student.Id);
            Assert.Equal("Jim", student.FirstName);
            Assert.Equal("Beam", student.LastName);
            Assert.Contains("Math", student.EnrolledSubjects);
            Assert.Contains("Science", student.EnrolledSubjects);
        }
    }
}
