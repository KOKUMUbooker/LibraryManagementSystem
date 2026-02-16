namespace LibraryManagementSystem.Tests;

using NUnit.Framework;
using LibraryManagementSystem.App.Models;
using LibraryManagementSystem.App.Services;

// public bool RemoveBook(Guid bookId)
// Should:
// Fail if book has active loans
// Remove from list
// Return true if removed

[TestFixture]
public class TestRemoveBook
{
    private LibraryService _libraryService = null!;

    [SetUp]
    public void Setup()
    {
        _libraryService = new LibraryService();
    }

    [Test]
    public void RemoveBook_ShouldFailIfBookHasActiveLoans()
    {
        // Arrange
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1, Guid.NewGuid());
        _libraryService.AddBook(book.Title,book.Author,book.TotalCopies,book.Id);

        Member member = _libraryService.RegisterMember("John Doe",Guid.NewGuid());

        var loan = new Loan(book.Id, member.Id);
        _libraryService.BorrowBook(member.Id,book.Id);

        // Act
        var result = _libraryService.RemoveBook(book.Id);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void RemoveBook_ShouldRemoveBookFromList()
    {
        // Arrange
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1,Guid.NewGuid());
        _libraryService.AddBook(book.Title,book.Author,book.TotalCopies,book.Id);

        // Act
        _libraryService.RemoveBook(book.Id);

        // Assert
        Assert.That(_libraryService.GetAllBooks(), Does.Not.Contain(book));
    }

    [Test]
    public void RemoveBook_ShouldReturnTrueIfRemoved()
    {
        // Arrange
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1,Guid.NewGuid());
        _libraryService.AddBook(book.Title,book.Author,book.TotalCopies,book.Id);

        // Act
        var result = _libraryService.RemoveBook(book.Id);

        // Assert
        Assert.That(result, Is.True);
    }
}
