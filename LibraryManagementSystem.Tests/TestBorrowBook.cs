namespace LibraryManagementSystem.Tests;

using NUnit.Framework;
using NUnit.Framework.Legacy;
using LibraryManagementSystem.App.Models;
using LibraryManagementSystem.App.Services;

// public string BorrowBook(Guid memberId, Guid bookId)
// Steps:
// Check member exists
// Check book exists
// Check AvailableCopies > 0
// Check member hasn’t already borrowed same book
// Create loan
// Decrease AvailableCopies

// Return messages like:
// "Book borrowed successfully."
// "Book not found."
// "No copies available."
// "Member not found."
// "Book already borrowed by this member."

[TestFixture]
public class TestBorrowBook
{
    [Test]
    public void BorrowBook_ShouldBorrowBookSuccessfully()
    {
        // Arrange
        LibraryService _libraryService = new LibraryService();
        var member = new Member("John Doe",Guid.NewGuid());
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald",Guid.NewGuid());
        _libraryService.RegisterMember(member.Name,member.Id);
        _libraryService.AddBook(book.Title,book.Author,book.TotalCopies, book.Id);

        // Act
        var result = _libraryService.BorrowBook(member.Id, book.Id);

        // Assert
        ClassicAssert.AreEqual("Book borrowed successfully.", result);
    }

    [Test]
    public void BorrowBook_ShouldReturnBookNotFoundIfBookDoesNotExist()
    {
        // Arrange
        LibraryService _libraryService = new LibraryService();
        var member = new Member("John Doe",Guid.NewGuid());
        _libraryService.RegisterMember(member.Name,member.Id);

        // Act
        var result = _libraryService.BorrowBook(member.Id, Guid.NewGuid());

        // Assert
        ClassicAssert.AreEqual("Book not found.", result);
    }

    [Test]
    public void BorrowBook_ShouldReturnNoCopiesAvailableIfNoCopiesAvailable()
    {
        // Arrange
        LibraryService _libraryService = new LibraryService();
        var member = new Member("John Doe",Guid.NewGuid());
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald",1,Guid.NewGuid());
        _libraryService.RegisterMember(member.Name,member.Id);
        _libraryService.AddBook(book.Title,book.Author,book.TotalCopies,book.Id);

        // Act
        _libraryService.BorrowBook(member.Id, book.Id);
        var result = _libraryService.BorrowBook(member.Id, book.Id);

        // Assert
        ClassicAssert.AreEqual("No copies available.", result);
    }

    [Test]
    public void BorrowBook_ShouldReturnMemberNotFoundIfMemberDoesNotExist()
    {
        // Arrange
        LibraryService _libraryService = new LibraryService();
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald",Guid.NewGuid());
        _libraryService.AddBook(book.Title,book.Author,book.TotalCopies,book.Id);

        // Act
        var result = _libraryService.BorrowBook(Guid.NewGuid(), book.Id);

        // Assert
        ClassicAssert.AreEqual("Member not found.", result);
    }

    [Test]
    public void BorrowBook_ShouldNotAllowBorrowingIfBookAlreadyBorrowedByMember()
    {
        // Arrange
        var _libraryService = new LibraryService();
        var member = new Member("John Doe",Guid.NewGuid());
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald",2, Guid.NewGuid());
        _libraryService.RegisterMember(member.Name,member.Id);
        _libraryService.AddBook(book.Title, book.Author, book.TotalCopies, book.Id);

        // Act
          _libraryService.BorrowBook(member.Id, book.Id);
        var result = _libraryService.BorrowBook(member.Id, book.Id);

        // Assert
        ClassicAssert.AreEqual("Book already borrowed by this member.", result);
    }

    [Test]
    public void BorrowBook_ShouldNotAllowBorrowingNonExistingBook()
    {
        // Arrange
        LibraryService _libraryService = new LibraryService();
        var member = new Member("John Doe",Guid.NewGuid());
        _libraryService.RegisterMember(member.Name,member.Id);

        // Act
        var result = _libraryService.BorrowBook(member.Id, Guid.NewGuid());

        // Assert
        ClassicAssert.AreEqual("Book not found.", result);
    }
}
