using NUnit.Framework;

// public bool RemoveBook(Guid bookId)
// Should:
// Fail if book has active loans
// Remove from list
// Return true if removed

[TestFixture]
public class TestRemoveBook
{
    [Test]
    public void RemoveBook_ShouldFailIfBookHasActiveLoans()
    {
        // Arrange
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1);
        var library = new Library();
        library.AddBook(book);

        var loan = new Loan(book, new User("John Doe", "john@example.com"));
        library.AddLoan(loan);

        // Act
        var result = library.RemoveBook(book.Id);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void RemoveBook_ShouldRemoveBookFromList()
    {
        // Arrange
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1);
        var library = new Library();
        library.AddBook(book);

        // Act
        library.RemoveBook(book.Id);

        // Assert
        Assert.That(library.Books, Does.Not.Contain(book));
    }

    [Test]
    public void RemoveBook_ShouldReturnTrueIfRemoved()
    {
        // Arrange
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1);
        var library = new Library();
        library.AddBook(book);

        // Act
        var result = library.RemoveBook(book.Id);

        // Assert
        Assert.That(result, Is.True);
    }
}
