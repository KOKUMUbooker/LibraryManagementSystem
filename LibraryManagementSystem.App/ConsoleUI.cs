using LibraryManagementSystem.App.Services;

public class ConsoleUI
{
    private readonly ILibraryService _service;

    public ConsoleUI(ILibraryService service)
    {
        _service = service;
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== Library Management System =====");
            Console.WriteLine("1. Manage Books");
            Console.WriteLine("2. Manage Members");
            Console.WriteLine("3. Borrow / Return");
            Console.WriteLine("0. Exit");
            Console.Write("Select option: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ManageBooksMenu();
                    break;
                case "2":
                    ManageMembersMenu();
                    break;
                case "3":
                    LoanMenu();
                    break;
                case "0":
                    return;
                default:
                    InvalidOption();
                    break;
            }
        }
    }

    private void ManageBooksMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== Manage Books =====");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View All Books");
            Console.WriteLine("3. Search Book");
            Console.WriteLine("4. Remove Book");
            Console.WriteLine("0. Back");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    ViewAllBooks();
                    break;
                case "3":
                    // SearchBooks();
                    break;
                case "4":
                    // RemoveBook();
                    break;
                case "0":
                    return;
                default:
                    InvalidOption();
                    break;
            }
        }   
    }

    private void AddBook()
    {
        Console.Clear();
        Console.Write("Title: ");
        var title = Console.ReadLine() ?? "";

        Console.Write("Author: ");
        var author = Console.ReadLine() ?? "";

        Console.Write("Copies: ");
        int.TryParse(Console.ReadLine(), out int copies);

        _service.AddBook(title, author, copies, Guid.NewGuid());

        Pause("Book added successfully.");
    }

    private void ViewAllBooks()
    {
        Console.Clear();
        var books = _service.GetAllBooks();

        if (!books.Any())
        {
            Pause("No books found.");
            return;
        }

        foreach (var book in books)
        {
            Console.WriteLine($"ID: {book.Id}");
            Console.WriteLine($"Title: {book.Title}");
            Console.WriteLine($"Author: {book.Author}");
            Console.WriteLine($"Available: {book.AvailableCopies}/{book.TotalCopies}");
            Console.WriteLine("-----------------------------------");
        }

        Pause();
    }

    private void ManageMembersMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== Manage Members =====");
            Console.WriteLine("1. Register Member");
            Console.WriteLine("2. View All Members");
            Console.WriteLine("0. Back");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    // RegisterMember();
                    break;
                case "2":
                    // ViewAllMembers();
                    break;
                case "0":
                    InvalidOption();
                    return;
            }
        }
    }

    private void LoanMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== Borrow / Return =====");
            Console.WriteLine("1. Borrow Book");
            Console.WriteLine("2. Return Book");
            Console.WriteLine("3. View Loans");
            Console.WriteLine("0. Back");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    // BorrowBook();
                    break;
                case "2":
                    // ReturnBook();
                    break;
                case "3":
                    // ViewLoans();
                    break;
                case "0":
                    InvalidOption();
                    return;
            }
        }
    }

    private void Pause(string? message = null)
    {
        if (!string.IsNullOrWhiteSpace(message))
            Console.WriteLine(message);

        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void InvalidOption()
    {
        Pause("Invalid option selected.");
    }
}
