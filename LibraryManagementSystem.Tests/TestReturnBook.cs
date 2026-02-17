namespace LibraryManagementSystem.Tests;

using NUnit.Framework;
using NUnit.Framework.Legacy;
using LibraryManagementSystem.App.Models;
using LibraryManagementSystem.App.Services;

// public string ReturnBook(Guid memberId, Guid bookId)
// Steps:
//     Find matching loan
//     If not found → error
//     Remove loan
//     Increase AvailableCopies
//     Return success message

[TestFixture]
public class TestReturnBook
{
    private LibraryService _libraryService = null!;

    [SetUp]
    public void Setup()
    {
        _libraryService = new LibraryService();
    }

    [Test]
    public void ReturnBook_WithValidMemberAndBook_ReturnsSuccessMessage()
    {
        // Arrange
        var member = new Member("John","jdoe@gmail.com", Guid.NewGuid());
        var book = new Book("Title", "Author",Guid.NewGuid());
        _libraryService.RegisterMember(member.Name, member.Email, member.Id);
        _libraryService.AddBook(book.Title,book.Author,book.TotalCopies,book.Id);
        _libraryService.BorrowBook(member.Id, book.Id);

        // Act
        var result = _libraryService.ReturnBook(member.Id, book.Id);

        // Assert
        ClassicAssert.AreEqual("Book returned successfully.", result);
    }

    [Test]
    public void ReturnBook_WithInvalidMember_ReturnsErrorMessage()
    {
        // Arrange
        var member = new Member("John","jdoe@gmail.com",Guid.NewGuid());
        var book = new Book("Title", "Author",Guid.NewGuid());
        _libraryService.RegisterMember(member.Name, member.Email, member.Id);
        _libraryService.AddBook(book.Title,book.Author,book.TotalCopies,book.Id);
        _libraryService.BorrowBook(member.Id, book.Id);

        // Act
        var result = _libraryService.ReturnBook(Guid.NewGuid(), book.Id);

        // Assert
        ClassicAssert.AreEqual("No loan found for this member and book.", result);
    }

    [Test]
    public void ReturnBook_WithInvalidBook_ReturnsErrorMessage()
    {
        // Arrange
        var member = new Member("John", "jdoe@gmail.com", Guid.NewGuid());
        _libraryService.RegisterMember(member.Name,member.Email,member.Id);

        // Act
        var result = _libraryService.ReturnBook(member.Id, Guid.NewGuid());

        // Assert
        ClassicAssert.AreEqual("No loan found for this member and book.", result);
    }

    [Test]
    public void ReturnBook_WithInvalidLoan_ReturnsErrorMessage()
    {
        // Arrange
        var member = new Member("John","jdoe@gmail.com", Guid.NewGuid());
        var book = new Book("Title", "Author",Guid.NewGuid());
        _libraryService.RegisterMember(member.Name, member.Email, member.Id);
        _libraryService.AddBook(book.Title,book.Author,book.TotalCopies,book.Id);
        _libraryService.BorrowBook(member.Id, book.Id);

        // Act
        var result = _libraryService.ReturnBook(Guid.NewGuid(), Guid.NewGuid());

        // Assert
        ClassicAssert.AreEqual("No loan found for this member and book.", result);
    }

    [Test]
    public void ReturnBook_IncreasesAvailableCopies()
    {
        // Arrange
        var member = new Member("John", "jdoe@gmail.com", Guid.NewGuid());
        var book = new Book("Title", "Author",Guid.NewGuid());
        _libraryService.RegisterMember(member.Name, "jdoe@gmail.com", member.Id);
        _libraryService.AddBook(book.Title,book.Author,book.TotalCopies,book.Id);
        _libraryService.BorrowBook(member.Id, book.Id);

        // Act
        _libraryService.ReturnBook(member.Id, book.Id);

        // Assert
        ClassicAssert.AreEqual(1, _libraryService.GetBookById(book.Id)?.AvailableCopies);
    }
}
