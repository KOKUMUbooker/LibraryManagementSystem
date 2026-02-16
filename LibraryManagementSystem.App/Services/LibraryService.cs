namespace LibraryManagementSystem.App.Services;

using LibraryManagementSystem.App.Models;

public class LibraryService : ILibraryService
{
    private readonly List<Book> _books = new();
    private readonly List<Member> _members = new();
    private readonly List<Loan> _loans = new();

    // Book Methods
    public Book AddBook(string title, string author, int copies, Guid id)
    {
        if (copies <= 0) throw new ArgumentException("Copies must be greater than 0");

        var book = new Book(title, author, copies, id);
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
    }

    public Book? GetBookById(Guid bookId)
    {
        return _books.FirstOrDefault(b => b.Id == bookId);
    }

    // Member Methods
    public Member RegisterMember(string name, Guid id)
    {
        var member = new Member(name,id);
        _members.Add(member);
        return member;
    }

    public List<Member> GetAllMembers()
    {
        return _members.ToList();
    }

    public Member? GetMemberById(Guid memberId)
    {
        return _members.FirstOrDefault(m => m.Id == memberId);
    }

    public Member? GetMemberByName(string name)
    {
        return _members.FirstOrDefault(m => m.Name == name);
    }

    // Borrowing Methods
    public string BorrowBook(Guid memberId, Guid bookId)
    {
        if (_members.Find(m => m.Id == memberId) == null) return "Member not found.";
        if (_books.Find(b => b.Id == bookId) == null) return "Book not found.";
        if (_books.Find(b => b.Id == bookId)!.AvailableCopies == 0) return "No copies available."; // We're sure a book exists
        if (_loans.Any(l => l.MemberId == memberId && l.BookId == bookId)) return "Book already borrowed by this member.";

        var loan = new Loan(memberId, bookId);
        _loans.Add(loan);
        _books.Find(b => b.Id == bookId)!.AvailableCopies--; // We're sure a book exists
        return "Book borrowed successfully.";
    }

    public string ReturnBook(Guid memberId, Guid bookId)
    {
        var loan = _loans.FirstOrDefault(l => l.MemberId == memberId && l.BookId == bookId);
        if (loan == null) return "No loan found for this member and book.";

        _loans.Remove(loan);
        int targetBookI = _books.FindIndex(b => b.Id == bookId);
        if (targetBookI >= 0) _books[targetBookI].AvailableCopies++;
        return "Book returned successfully.";
    }

    public List<Loan> GetAllLoans()
    {
        return _loans.ToList();
    }
}
