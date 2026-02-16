# Library Management System
## Description
- This is a library management system written in C# using .NET Core and NUnit with a focus on Test Driven Development (TDD).

## Project info
### Iteration 1: Add Books and Retrieve Information
In this iteration, the focus is on creating a basic library management system that allows users to add books to the library and retrieve information about the books including the title, author and ISBN

Here are some user stories that could be used to define the features for this iteration:
- As a user, I want to be able to add a book to the library so that I can keep track of my collection.
- As a user, I want to be able to retrieve information about a book so that I can find out more about it.
==========================================================================================================

### Iteration 2: Search by Author
In this iteration, the focus is on adding the ability to search for books by author. This will allow users to find books by a specific author more easily.
- As a librarian, I want to be able to search for books by author so that I can find books by a specific author.
- As a librarian, I want to see a list of all books by a specific author so that I can find books by a specific author.

==========================================================================================================

### Iteration 3: Search by ISBN
In this iteration, the focus is on enabling the user to search for books by ISBN. This will allow users to find books by a specific ISBN more easily.
- As a librarian, I want to be able to search for books by ISBN so that I can find books by a specific ISBN.
- As a librarian, I want to see information about a particular book based on its ISBN, so that I can verify its details.

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
