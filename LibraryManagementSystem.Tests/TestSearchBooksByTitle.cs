namespace LibraryManagementSystem.Tests;

using NUnit.Framework;
using NUnit.Framework.Legacy;
using LibraryManagementSystem.App.Models;
using LibraryManagementSystem.App.Services;

// public List<Book> SearchBooksByTitle(string title)
// Should:
// Case insensitive search
// Return matching list
[TestFixture]
public class TestSearchBooksByTitle
{

    private LibraryService _libraryService = null!;

    [SetUp]
    public void Setup()
    {
        _libraryService = new LibraryService();
    }

    [Test]
    public void SearchBooksByTitle_ShouldReturnMatchingList()
    {
        // Arrange
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1,Guid.NewGuid());
        _libraryService.AddBook(book.Title, book.Author, book.TotalCopies, book.Id);
 
        // Act
        var result = _libraryService.SearchBooksByTitle("The Great Gatsby");

        // Assert
        ClassicAssert.AreEqual(1, result.Count);
        ClassicAssert.AreEqual(book.Id, result[0].Id);
    }

    [Test]
    public void SearchBooksByTitle_ShouldReturnMatchingList_CaseInsensitive()
    {
        // Arrange
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1,Guid.NewGuid());
        _libraryService.AddBook(book.Title, book.Author, book.TotalCopies, book.Id);

        // Act
        var result = _libraryService.SearchBooksByTitle("the great gatsby");

        // Assert
        ClassicAssert.AreEqual(1, result.Count);
        ClassicAssert.AreEqual(book.Id, result[0].Id);
    }

    [Test]
    public void SearchBooksByTitle_ShouldReturnMatchingListForLowercaseQuery()
    {
        // Arrange
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1,Guid.NewGuid());
        _libraryService.AddBook(book.Title, book.Author, book.TotalCopies, book.Id);

        // Act
        var result = _libraryService.SearchBooksByTitle("gatsby");

        // Assert
        ClassicAssert.AreEqual(1, result.Count);
        ClassicAssert.AreEqual(book.Id, result[0].Id);
    }

    [Test]
    public void SearchBooksByTitle_ShouldReturnEmptyListForNonexistentTitle()
    {
        // Arrange

        // Act
        var result = _libraryService.SearchBooksByTitle("nonexistent");

        // Assert
        ClassicAssert.AreEqual(0, result.Count);
    }
}
