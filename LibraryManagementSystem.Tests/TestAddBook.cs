using NUnit.Framework;

namespace LibraryManagementSystem.Tests;

// public Book AddBook(string title, string author, int copies)
// Should:
// Validate copies > 0
// Create book
// Set AvailableCopies = TotalCopies
// Add to _books
// Return created book

public class TestAddBook
{
    private readonly LibraryService _libraryService = new();

    [SetUp]
    public void Setup()
    {
        _libraryService = new();
    }

    [Test]
    public void AddBook_ShouldReturnBookWithCorrectDetails()
    {
        var book = _libraryService.AddBook("The Great Gatsby", "F. Scott Fitzgerald", 1);

        Assert.That(book.Title, Is.EqualTo("The Great Gatsby"));
        Assert.That(book.Author, Is.EqualTo("F. Scott Fitzgerald"));
        Assert.That(book.Copies, Is.EqualTo(1));
    }

    [Test]
    public void AddBook_ShouldThrowExceptionWhenCopiesIsZero()
    {
        Assert.Throws<ArgumentException>(() => _libraryService.AddBook("The Great Gatsby", "F. Scott Fitzgerald", 0));
    }

    [Test]
    public void AddBook_ShouldThrowExceptionWhenCopiesIsNegative()
    {
        Assert.Throws<ArgumentException>(() => _libraryService.AddBook("The Great Gatsby", "F. Scott Fitzgerald", -1));
    }

    [Test]
    public void AddBook_ShouldCreateBookWithCorrectDetails()
    {
        var book = _libraryService.AddBook("The Great Gatsby", "F. Scott Fitzgerald", 1);

        Assert.That(book.Title, Is.EqualTo("The Great Gatsby"));
        Assert.That(book.Author, Is.EqualTo("F. Scott Fitzgerald"));
        Assert.That(book.Copies, Is.EqualTo(1));
        Assert.That(book.AvailableCopies, Is.EqualTo(1));
    }

    [Test]
    public void AddBook_ShouldAddBookToLibrary()
    {
        var book = _libraryService.AddBook("The Great Gatsby", "F. Scott Fitzgerald", 1);

        Assert.That(_libraryService.GetBooks(), Contains.Item(book));
    }
}
