using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using MyAvaloniaMVVMApp.Models;
using MyAvaloniaMVVMApp.Services;
using Xunit;

namespace MyAvaloniaMVVMApp.Tests
{
    public class JsonServiceTests
    {
        private readonly JsonService _jsonService;
        private const string JsonFilePath = "Data/people.json";

        public JsonServiceTests()
        {
            _jsonService = new JsonService();
            // Ensure the directory exists for the test
            Directory.CreateDirectory("Data");
        }

        [Fact]
        public void LoadPeople_FileDoesNotExist_ReturnsEmptyPeople()
        {
            // Arrange
            // Ensure the JSON file does not exist for this test
            if (File.Exists(JsonFilePath))
            {
                File.Delete(JsonFilePath);
            }

            // Act
            var result = _jsonService.LoadPeople();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.Teachers);
            Assert.Empty(result.Students);
        }

        [Fact]
        public void LoadPeople_ValidJson_ReturnsPeople()
        {
            // Arrange
            var people = new People
            {
                Teachers = new List<Teacher>
                {
                    new Teacher { Id = 1, FirstName = "John", LastName = "Doe", Login = "jdoe", Password = "password123" }
                },
                Students = new List<Student>
                {
                    new Student { Id = 1, FirstName = "Jane", LastName = "Doe", Login = "jane", Password = "password456" }
                }
            };
            File.WriteAllText(JsonFilePath, JsonSerializer.Serialize(people));

            // Act
            var result = _jsonService.LoadPeople();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.Teachers);
            Assert.Single(result.Students);
        }

        [Fact]
        public void LoadPeople_InvalidJson_ReturnsEmptyPeople()
        {
            // Arrange
            File.WriteAllText(JsonFilePath, "Invalid JSON");

            // Act
            var result = _jsonService.LoadPeople();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.Teachers);
            Assert.Empty(result.Students);
        }
    }
}
