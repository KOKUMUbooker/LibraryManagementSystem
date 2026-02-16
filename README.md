# Library Management System
## Description
- This is a library management system written in C# using .NET Core and NUnit with a focus on Test Driven Development (TDD).

## Steps to re-create project
1. Make directory `LibraryManagementSystem`
  ```bash
mkdir LibraryManagementSystem
cd LibraryManagementSystem 
 ```
2. Generate solution file
  ```bash
dotnet new sln
 ```
3. Create a new project
  ```bash
dotnet new console -n LibraryManagementSystem.App
 ```
4. Add project to solution
  ```bash
dotnet sln add LibraryManagementSystem.App/LibraryManagementSystem.App.csproj
```
5. Create test project
  ```bash
dotnet new xunit -n LibraryManagementSystem.Tests
```
6. Add test project to solution
  ```bash
dotnet sln add LibraryManagementSystem.Tests/LibraryManagementSystem.Tests.csproj
```
7. Make the test project be able to reference the main project
  ```bash
  dotnet add LibraryManagementSystem.Tests/LibraryManagementSystem.Tests.csproj reference LibraryManagementSystem.App/LibraryManagementSystem.App.csproj
```

## Steps to run project
1. Run the project
  ```bash
dotnet run --project LibraryManagementSystem.App/LibraryManagementSystem.App.csproj
```
2. Run the tests
  ```bash
dotnet test LibraryManagementSystem.Tests/LibraryManagementSystem.Tests.csproj
```
