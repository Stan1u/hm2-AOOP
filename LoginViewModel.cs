﻿using ReactiveUI;
using MyAvaloniaMVVMApp.Models;
using MyAvaloniaMVVMApp.Services;
using MyAvaloniaMVVMApp.Views;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls;
using Avalonia;
using System.Reactive;
using System.IO;

namespace MyAvaloniaMVVMApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _login = string.Empty;
        private string _password = string.Empty;
        private string _errorMessage = string.Empty;

        public string Login
        {
            get => _login;
            set => this.RaiseAndSetIfChanged(ref _login, value);
        }

        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => this.RaiseAndSetIfChanged(ref _errorMessage, value);
        }

        public ReactiveCommand<Unit, Unit> LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = ReactiveCommand.Create(OnLogin);
        }

        private void OnLogin()
        {
            Log("Rozpoczęcie logowania...");

            var jsonService = new JsonService();
            var people = jsonService.LoadPeople();

            if (people == null)
            {
                ErrorMessage = "Błąd ładowania danych użytkowników.";
                Log("Błąd: Nie udało się załadować pliku JSON.");
                return;
            }

            Person? loggedInUser = null;

            
            if (people.Teachers != null)
            {
                foreach (var teacher in people.Teachers)
                {
                    if (teacher.Login == Login && teacher.Password == Password)
                    {
                        loggedInUser = teacher;
                        break;
                    }
                }
            }

            
            if (loggedInUser == null && people.Students != null)
            {
                foreach (var student in people.Students)
                {
                    if (student.Login == Login && student.Password == Password)
                    {
                        loggedInUser = student;
                        break;
                    }
                }
            }

            
            if (loggedInUser == null && Login == "admin" && Password == "admin123")
            {
                loggedInUser = new Person { FirstName = "Admin", LastName = "Admin" };
            }

            
            if (loggedInUser != null)
            {
                Log($"Zalogowano użytkownika: {loggedInUser.FirstName} {loggedInUser.LastName}");

                Window nextWindow = null;

                if (loggedInUser is Teacher teacher)
                {
                    nextWindow = new TeacherView
                    {
                        DataContext = new TeacherViewModel(teacher)
                    };
                }
                else if (loggedInUser is Student student)
                {
                    nextWindow = new StudentView
                    {
                        DataContext = new StudentViewModel(student)
                    };
                }
                else if (Login == "admin" && Password == "admin123")
                {
                    nextWindow = new AdminView
                    {
                        DataContext = new AdminViewModel(people)
                    };
                }

                if (nextWindow != null)
                {
                    Log("Nowe okno otwarte.");
                    nextWindow.Show();

                    
                    if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                    {
                        desktop.MainWindow = nextWindow;
                        Log("Zmieniono główne okno aplikacji.");
                    }
                }
            }
            else
            {
                ErrorMessage = "Nieprawidłowy login lub hasło.";
                Log($"Nieudana próba logowania: {Login}");
            }
        }

        private void Log(string message)
        {
            File.AppendAllText("log.txt", $"{System.DateTime.Now}: {message}\n");
        }
    }
}
