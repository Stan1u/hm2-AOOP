# MyAvaloniaMVVMApp

## Description
MyAvaloniaMVVMApp is a desktop application built using the Avalonia framework, following the MVVM (Model-View-ViewModel) design pattern. The application provides a user-friendly interface for managing various functionalities.

## Application Structure
- **Program.cs**: The entry point of the application, responsible for initializing the Avalonia application.
- **App.axaml**: Defines the application resources and styles.
- **App.axaml.cs**: Contains the application logic, including the initialization of the main window.
- **Views/**: Contains the XAML files for the application's views.
- **ViewModels/**: Contains the view model classes that handle the application's logic and data binding.

### ViewModels
- **LoginViewModel**: 
  - **Variables**:
    - `_login`: Holds the user's login input.
    - `_password`: Holds the user's password input.
    - `_errorMessage`: Holds any error messages related to login.
  - **Properties**:
    - `Login`: Gets or sets the login value.
    - `Password`: Gets or sets the password value.
    - `ErrorMessage`: Gets or sets the error message value.
  - **Methods**:
    - `LoginCommand`: Triggers the `OnLogin` method.
    - `OnLogin()`: Handles the login logic, checks user credentials, and opens the corresponding view.
    - `Log(string message)`: Appends log messages to a `log.txt` file.

- **StudentViewModel**:
  - **Variables**:
    - `_student`: Holds the student's data.
  - **Properties**:
    - `FullName`: Returns the full name of the student.
    - `EnrolledSubjects`: Returns a list of subjects the student is enrolled in.
  - **Constructor**: Initializes the `_student` variable.

- **TeacherViewModel**:
  - **Variables**:
    - `_teacher`: Holds the teacher's data.
  - **Properties**:
    - `FullName`: Returns the full name of the teacher.
    - `Subject`: Returns the subject the teacher is assigned to.
  - **Constructor**: Initializes the `_teacher` variable.

- **AdminViewModel**:
  - **Variables**:
    - `_people`: Holds the collection of teachers and students.
  - **Properties**:
    - `Teachers`: Returns a list of teachers.
    - `Students`: Returns a list of students.
  - **Constructor**: Initializes the `_people` variable.

- **JsonService**:
  - **Variables**:
    - `JsonFilePath`: Holds the path to the JSON file.
  - **Methods**:
    - `LoadPeople()`: Loads the data from the JSON file and returns a `People` object.

### Views
- **AdminView**:
  - **Constructors**:
    - `AdminView()`: Initializes the component.
    - `AdminView(People people)`: Initializes the component and sets the `DataContext` to a new `AdminViewModel`.

- **StudentView**:
  - **Constructors**:
    - `StudentView()`: Initializes the component.
    - `StudentView(Student student)`: Initializes the component and sets the `DataContext` to a new `StudentViewModel`.

- **TeacherView**:
  - **Constructors**:
    - `TeacherView()`: Initializes the component.
    - `TeacherView(Teacher teacher)`: Initializes the component and sets the `DataContext` to a new `TeacherViewModel`.

##### Note about issues
Couldn't solve the problem with infinite loop which occures when login button is clicked. Test should work if the issue was solved. I was trying AI to cluch the situaton but nither chatGPT, Deepseek or Blackbox could find a way to repair it. Project included all base requirements + admin (works differently than described in requirements but I didnt do it the way it was described cuz there is infinite loop anyway) + Tests which worked but at point when the loop occured for the first time they stopped working (I guess that makes sens). Hope thats enough for some points and sry for making u check this mess. Have a nice day!