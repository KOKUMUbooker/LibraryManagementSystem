namespace LibraryManagementSystem.App.Services;

using LibraryManagementSystem.App.Models;

public class LibraryService
{
    private readonly List<Book> _books = new();
    private readonly List<Member> _members = new();
    private readonly List<Loan> _loans = new();

    // Book Methods
    public Book AddBook(string title, string author, int copies);
    public bool RemoveBook(Guid bookId);
    public List<Book> GetAllBooks();
    public List<Book> SearchBooksByTitle(string title);

    // Member Methods
    public Member RegisterMember(string name);
    public List<Member> GetAllMembers();
    public Member? GetMemberById(Guid memberId);

    // Borrowing Methods
    public string BorrowBook(Guid memberId, Guid bookId);
    public string ReturnBook(Guid memberId, Guid bookId);
    public List<Loan> GetAllLoans();
}
