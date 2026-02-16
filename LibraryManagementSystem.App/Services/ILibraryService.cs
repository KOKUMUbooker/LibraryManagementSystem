using LibraryManagementSystem.App.Models;

namespace LibraryManagementSystem.App.Services;

public interface ILibraryService
{
    // Book Management
    Book AddBook(string title, string author, int copies);
    bool RemoveBook(Guid bookId);
    List<Book> GetAllBooks();
    List<Book> SearchBooksByTitle(string title);
    Book? GetBookById(Guid bookId);

    // Member Management
    Member RegisterMember(string name);
    List<Member> GetAllMembers();
    Member? GetMemberById(Guid memberId);

    // Borrowing
    string BorrowBook(Guid memberId, Guid bookId);
    string ReturnBook(Guid memberId, Guid bookId);
    List<Loan> GetAllLoans();
}
