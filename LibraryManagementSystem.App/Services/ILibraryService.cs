using LibraryManagementSystem.App.Models;

namespace LibraryManagementSystem.App.Services;

public interface ILibraryService
{
    // Book Management
    public Book AddBook(string title, string author, int copies, Guid id);
    bool RemoveBook(Guid bookId);
    List<Book> GetAllBooks();
    List<Book> SearchBooksByTitle(string title);
    Book? GetBookById(Guid bookId);

    // Member Management
    Member RegisterMember(string name, string email, Guid id);
    List<Member> GetAllMembers();
    Member? GetMemberById(Guid memberId);
    Member? GetMemberByName(string name);
    Member? GetMemberByEmail(string email);

    // Borrowing
    string BorrowBook(Guid memberId, Guid bookId);
    string ReturnBook(Guid memberId, Guid bookId);
    List<Loan> GetAllLoans();
}
