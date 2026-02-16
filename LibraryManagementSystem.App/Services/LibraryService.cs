namespace LibraryManagementSystem.App.Services;

using LibraryManagementSystem.App.Models;

public class LibraryService : ILibraryService
{
    private readonly List<Book> _books = new();
    private readonly List<Member> _members = new();
    private readonly List<Loan> _loans = new();

    // Book Methods
    public Book AddBook(string title, string author, int copies)
    {
        if (copies <= 0) throw new ArgumentException("Copies must be greater than 0");

        var book = new Book(title, author, copies);
        _books.Add(book);
        return book;
    }

    public bool RemoveBook(Guid bookId)
    {
        var book = _books.FirstOrDefault(b => b.Id == bookId);
        if (book == null) return false;

        if (_loans.Any(l => l.BookId == bookId)) return false; // If has active loans

        _books.Remove(book);
        return true;
    }

    public List<Book> GetAllBooks()
    {
        return _books.ToList();
    }

    public List<Book> SearchBooksByTitle(string title)
    {
        return _books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
    };

    // Member Methods
    public Member RegisterMember(string name);
    public List<Member> GetAllMembers();
    public Member? GetMemberById(Guid memberId);

    // Borrowing Methods
    public string BorrowBook(Guid memberId, Guid bookId);
    public string ReturnBook(Guid memberId, Guid bookId);
    public List<Loan> GetAllLoans();
}
