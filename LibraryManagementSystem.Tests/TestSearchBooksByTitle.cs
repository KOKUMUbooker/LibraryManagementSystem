using NUnit.Framework;

namespace LibraryManagementSystem.Tests;

// public List<Book> SearchBooksByTitle(string title)
// Should:
// Case insensitive search
// Return matching list
[TestFixture]
public class TestSearchBooksByTitle
{
    [Test]
    public void TestSearchBooksByTitle()
    {
        // Arrange
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1);
        var member = new Member("John Doe", "john.doe@example.com");
        var loan = new Loan(book, member);

        // Act
        var result = LibraryManagementSystem.SearchBooksByTitle("The Great Gatsby");

        // Assert
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(book.Id, result[0].Id);
    }

    [Test]
    public void TestSearchBooksByTitle_CaseInsensitive()
    {
        // Arrange
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1);
        var member = new Member("John Doe", "john.doe@example.com");
        var loan = new Loan(book, member);

        // Act
        var result = LibraryManagementSystem.SearchBooksByTitle("the great gatsby");

        // Assert
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(book.Id, result[0].Id);
    }

    [Test]
    public void TestSearchBooksByTitle_ReturnMatchingList()
    {
        // Arrange
        var book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1);
        var book2 = new Book("To Kill a Mockingbird", "Harper Lee", 2);
        var member = new Member("John Doe", "john.doe@example.com");
        var loan1 = new Loan(book1, member);
        var loan2 = new Loan(book2, member);

        // Act
        var result = LibraryManagementSystem.SearchBooksByTitle("gatsby");

        // Assert
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(book1.Id, result[0].Id);
    }

    [Test]
    public void TestSearchBooksByTitle_ReturnEmptyList()
    {
        // Arrange
        var book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1);
        var book2 = new Book("To Kill a Mockingbird", "Harper Lee", 2);
        var member = new Member("John Doe", "john.doe@example.com");
        var loan1 = new Loan(book1, member);
        var loan2 = new Loan(book2, member);

        // Act
        var result = LibraryManagementSystem.SearchBooksByTitle("nonexistent");

        // Assert
        Assert.AreEqual(0, result.Count);
    }
}
