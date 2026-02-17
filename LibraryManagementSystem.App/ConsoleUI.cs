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
            Console.Write("Select option: ");

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
                    SearchBooks();
                    break;
                case "4":
                    RemoveBook();
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

    private void SearchBooks()
    {
        Console.Clear();
        Console.Write("Enter title to search: ");
        var title = Console.ReadLine() ?? "";

        var results = _service.SearchBooksByTitle(title);

        if (results.Count == 0)
        {
            Pause("No matching books found.");
            return;
        }

        foreach (var book in results)
        {
            Console.WriteLine($"ID: {book.Id}");
            Console.WriteLine($"Title: {book.Title}");
            Console.WriteLine($"Author: {book.Author}");
            Console.WriteLine($"Available: {book.AvailableCopies}/{book.TotalCopies}");
            Console.WriteLine("-----------------------------------");
        }

        Pause();
    }

    private void RemoveBook()
    {
        Console.Clear();
        Console.Write("Enter Book ID to remove: ");

        if (!Guid.TryParse(Console.ReadLine(), out Guid bookId))
        {
            Pause("Invalid GUID format.");
            return;
        }

        var success = _service.RemoveBook(bookId);

        if (success)
            Pause("Book removed successfully.");
        else
            Pause("Book not found.");
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
            Console.Write("Select option: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    RegisterMember();
                    break;
                case "2":
                    ViewAllMembers();
                    break;
                case "0":
                    return;
                default:
                    InvalidOption();
                    break;
            }
        }
    }

    private void RegisterMember()
    {
        Console.Clear();
        Console.Write("Enter member name: ");
        var name = Console.ReadLine() ?? "";

        Console.Write("Enter member email: ");
        var email = Console.ReadLine() ?? "";

        var emailExists = _service.GetMemberByEmail(email);
        if (emailExists != null)
        {
            Pause($"Email : {email} already taken");
        }
        else
        {
            var member = _service.RegisterMember(name, email, Guid.NewGuid());

            Pause($"Member registered successfully. ID: {member.Id}");
        }
    }

    private void ViewAllMembers()
    {
        Console.Clear();
        var members = _service.GetAllMembers();

        if (members.Count == 0)
        {
            Pause("No members found.");
            return;
        }

        foreach (var member in members)
        {
            Console.WriteLine($"ID: {member.Id}");
            Console.WriteLine($"Name: {member.Name}");
            Console.WriteLine($"Email: {member.Email}");
            Console.WriteLine("-----------------------------------");
        }

        Pause();
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
            Console.Write("Select option: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    BorrowBook();
                    break;
                case "2":
                    ReturnBook();
                    break;
                case "3":
                    ViewLoans();
                    break;
                case "0":
                    return;
                default:
                    InvalidOption();
                    break;
            }
        }
    }

    private void BorrowBook()
    {
        Console.Clear();

        Console.Write("Enter Member ID: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid memberId))
        {
            Pause("Invalid Member ID.");
            return;
        }

        Console.Write("Enter Book ID: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid bookId))
        {
            Pause("Invalid Book ID.");
            return;
        }

        var result = _service.BorrowBook(memberId, bookId);
        Pause(result);
    }

    private void ReturnBook()
    {
        Console.Clear();

        Console.Write("Enter Member ID: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid memberId))
        {
            Pause("Invalid Member ID.");
            return;
        }

        Console.Write("Enter Book ID: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid bookId))
        {
            Pause("Invalid Book ID.");
            return;
        }

        var result = _service.ReturnBook(memberId, bookId);
        Pause(result);
    }
    
    private void ViewLoans()
    {
        Console.Clear();
        var loans = _service.GetAllLoans();

        if (loans.Count == 0)
        {
            Pause("No active loans.");
            return;
        }

        foreach (var loan in loans)
        {
            Console.WriteLine($"Member ID: {loan.MemberId}");
            Console.WriteLine($"Book ID: {loan.BookId}");
            Console.WriteLine($"Borrow Date (UTC): {loan.BorrowDate}");
            Console.WriteLine("-----------------------------------");
        }

        Pause();
    }

    private void Pause(string? message = null)
    {
        if (!string.IsNullOrWhiteSpace(message)) Console.WriteLine(message);

        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void InvalidOption()
    {
        Pause("Invalid option selected.");
    }
}
