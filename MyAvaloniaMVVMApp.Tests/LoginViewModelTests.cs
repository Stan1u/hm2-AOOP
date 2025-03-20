using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Threading;
using MyAvaloniaMVVMApp.Models;
using MyAvaloniaMVVMApp.Services;
using MyAvaloniaMVVMApp.ViewModels;
using Xunit;

namespace MyAvaloniaMVVMApp.Tests
{
    public class LoginViewModelTests
    {
        private readonly LoginViewModel _loginViewModel;

        public LoginViewModelTests()
        {
            _loginViewModel = new LoginViewModel();
        }

        [Fact]
        public void LoginCommand_ValidTeacherCredentials_NavigatesToTeacherView()
        {
            // Arrange
            _loginViewModel.Login = "jdoe"; // Assuming this teacher exists in the JSON
            _loginViewModel.Password = "password123";

            // Act
            var task = _loginViewModel.LoginCommand.Execute();
            task.Subscribe();

            // Assert
            Assert.Null(_loginViewModel.ErrorMessage);
            // Additional assertions to verify navigation to TeacherView can be added here
        }

        [Fact]
        public void LoginCommand_InvalidCredentials_SetsErrorMessage()
        {
            // Arrange
            _loginViewModel.Login = "invalidUser";
            _loginViewModel.Password = "invalidPassword";

            // Act
            var task = _loginViewModel.LoginCommand.Execute();
            task.Subscribe();

            // Assert
            Assert.Equal("Nieprawidłowy login lub hasło.", _loginViewModel.ErrorMessage);
        }

        [Fact]
        public void LoginCommand_AdminCredentials_NavigatesToAdminView()
        {
            // Arrange
            _loginViewModel.Login = "admin";
            _loginViewModel.Password = "admin123";

            // Act
            var task = _loginViewModel.LoginCommand.Execute();
            task.Subscribe();

            // Assert
            Assert.Null(_loginViewModel.ErrorMessage);
            // Additional assertions to verify navigation to AdminView can be added here
        }
    }
}
