using System.Collections.Generic;

namespace MyAvaloniaMVVMApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }

    public class Teacher : Person
    {
        public string? Subject { get; set; }
    }

    public class Student : Person
    {
        public List<string>? EnrolledSubjects { get; set; }
    }

    public class People
    {
        public List<Teacher>? Teachers { get; set; }
        public List<Student>? Students { get; set; }
    }
}