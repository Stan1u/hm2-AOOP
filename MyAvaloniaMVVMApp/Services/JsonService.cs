using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using MyAvaloniaMVVMApp.Models;

namespace MyAvaloniaMVVMApp.Services
{
    public class JsonService
    {
        private const string JsonFilePath = "Data/people.json";

        public People LoadPeople()
        {
            try
            {
                if (!File.Exists(JsonFilePath))
                {
                    Console.WriteLine("JSON file not found. Returning empty data.");
                    return new People { Teachers = new List<Teacher>(), Students = new List<Student>() };
                }

                string jsonString = File.ReadAllText(JsonFilePath);
                var people = JsonSerializer.Deserialize<People>(jsonString);

                return people ?? new People { Teachers = new List<Teacher>(), Students = new List<Student>() };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON file: {ex.Message}");
                return new People { Teachers = new List<Teacher>(), Students = new List<Student>() };
            }
        }
    }
}
