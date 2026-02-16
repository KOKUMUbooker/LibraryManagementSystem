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
    Member RegisterMember(string name, Guid id);
    List<Member> GetAllMembers();
    Member? GetMemberById(Guid memberId);
    Member? GetMemberByName(string name);

    // Borrowing
    string BorrowBook(Guid memberId, Guid bookId);
    string ReturnBook(Guid memberId, Guid bookId);
    List<Loan> GetAllLoans();
}
