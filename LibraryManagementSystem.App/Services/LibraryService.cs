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
    public Member RegisterMember(string name, string email,Guid id)
    {
        var member = new Member(name, email, id);
        _members.Add(member);
        return member;
    }

    public bool RemoveMember(Guid memberId)
    {
        var memberI = _members.FindIndex(m => m.Id == memberId);
        if (memberI >= 0)
        {
            _members.RemoveAt(memberI);
            return true;
        }
        return false;
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

    public Member? GetMemberByEmail(string email)
    {
        return _members.FirstOrDefault(m => m.Email == email);
    }

    // Borrowing Methods
    public string BorrowBook(Guid memberId, Guid bookId)
    {
        var member = _members.FirstOrDefault(m => m.Id == memberId);
        if (member == null) return "Member not found.";
        if (_books.Find(b => b.Id == bookId) == null) return "Book not found.";
        if (_books.Find(b => b.Id == bookId)!.AvailableCopies == 0) return "No copies available."; // We're sure a book exists
        if (_loans.Any(l => l.MemberId == memberId && l.BookId == bookId)) return "Book already borrowed by this member.";

        var loan = new Loan(bookId, member.Email, memberId);
        _loans.Add(loan);
        int targetBookI = _books.FindIndex(b => b.Id == bookId); 
        if (targetBookI >= 0) _books[targetBookI].AvailableCopies--;

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


    public void SeedData()
    {
        // ===== BOOKS =====
        var book1 = new Book("Clean Code", "Robert C. Martin", 3, Guid.NewGuid());
        var book2 = new Book("The Pragmatic Programmer", "Andrew Hunt", 2, Guid.NewGuid());
        var book3 = new Book("Design Patterns", "Erich Gamma", 4, Guid.NewGuid());
        var book4 = new Book("Domain-Driven Design", "Eric Evans", 1, Guid.NewGuid());
        var book5 = new Book("Refactoring", "Martin Fowler", 2, Guid.NewGuid());

        _books.AddRange(new[] { book1, book2, book3, book4, book5 });

        // ===== MEMBERS =====
        var member1 = new Member("Alice Johnson", "alice@example.com", Guid.NewGuid());
        var member2 = new Member("Bob Smith", "bob@example.com", Guid.NewGuid());
        var member3 = new Member("Charlie Brown", "charlie@example.com", Guid.NewGuid());
        var member4 = new Member("Diana Prince", "diana@example.com", Guid.NewGuid());
        var member5 = new Member("Ethan Clark", "ethan@example.com", Guid.NewGuid());

        _members.AddRange(new[] { member1, member2, member3, member4, member5 });

        // ===== LOANS =====
        // Alice borrows Clean Code
        _loans.Add(new Loan(book1.Id, member1.Email, member1.Id));
        book1.AvailableCopies--;

        // Bob borrows Design Patterns
        _loans.Add(new Loan(book3.Id, member2.Email, member2.Id));
        book3.AvailableCopies--;

        // Charlie borrows The Pragmatic Programmer
        _loans.Add(new Loan(book2.Id, member3.Email, member3.Id));
        book2.AvailableCopies--;
    }
}
