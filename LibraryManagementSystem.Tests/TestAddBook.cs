namespace LibraryManagementSystem.Tests;

using NUnit.Framework;
using LibraryManagementSystem.App.Services;

// public Book AddBook(string title, string author, int copies)
// Should:
// Validate copies > 0
// Create book
// Set AvailableCopies = TotalCopies
// Add to _books
// Return created book

public class TestAddBook
{
    private LibraryService _libraryService = null!;

    [SetUp]
    public void Setup()
    {
        _libraryService = new LibraryService();
    }

    [Test]
    public void AddBook_ShouldReturnBookWithCorrectDetails()
    {
        var book = _libraryService.AddBook("The Great Gatsby", "F. Scott Fitzgerald", 1,Guid.NewGuid());

        Assert.That(book.Title, Is.EqualTo("The Great Gatsby"));
        Assert.That(book.Author, Is.EqualTo("F. Scott Fitzgerald"));
        Assert.That(book.AvailableCopies, Is.EqualTo(1));
    }

    [Test]
    public void AddBook_ShouldThrowExceptionWhenCopiesIsZero()
    {
        Assert.Throws<ArgumentException>(() => _libraryService.AddBook("The Great Gatsby", "F. Scott Fitzgerald", 0,Guid.NewGuid()));
    }

    [Test]
    public void AddBook_ShouldThrowExceptionWhenCopiesIsNegative()
    {
        Assert.Throws<ArgumentException>(() => _libraryService.AddBook("The Great Gatsby", "F. Scott Fitzgerald", -1,Guid.NewGuid()));
    }

    [Test]
    public void AddBook_ShouldCreateBookWithCorrectDetails()
    {
        var book = _libraryService.AddBook("The Great Gatsby", "F. Scott Fitzgerald", 1, Guid.NewGuid());

        Assert.That(book.Title, Is.EqualTo("The Great Gatsby"));
        Assert.That(book.Author, Is.EqualTo("F. Scott Fitzgerald"));
        Assert.That(book.AvailableCopies, Is.EqualTo(1));
    }

    [Test]
    public void AddBook_ShouldAddBookToLibrary()
    {
        var book = _libraryService.AddBook("The Great Gatsby", "F. Scott Fitzgerald", 1, Guid.NewGuid());

        Assert.That(_libraryService.GetAllBooks(), Contains.Item(book));
    }
}
