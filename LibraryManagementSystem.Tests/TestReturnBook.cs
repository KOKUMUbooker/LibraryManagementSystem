using NUnit.Framework;

namespace LibraryManagementSystem.Tests

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
    [Test]
    public void ReturnBook_WithValidMemberAndBook_ReturnsSuccessMessage()
    {
        // Arrange
        var system = new LibraryManagementSystem();
        var member = new Member("John");
        var book = new Book("Title", "Author");
        system.RegisterMember(member);
        system.RegisterBook(book);
        system.BorrowBook(member.Id, book.Id);

        // Act
        var result = system.ReturnBook(member.Id, book.Id);

        // Assert
        Assert.AreEqual("Book returned successfully.", result);
    }

    [Test]
    public void ReturnBook_WithInvalidMember_ReturnsErrorMessage()
    {
        // Arrange
        var system = new LibraryManagementSystem();
        var member = new Member("John");
        var book = new Book("Title", "Author");
        system.RegisterMember(member);
        system.RegisterBook(book);
        system.BorrowBook(member.Id, book.Id);

        // Act
        var result = system.ReturnBook(Guid.NewGuid(), book.Id);

        // Assert
        Assert.AreEqual("Member not found.", result);
    }

    [Test]
    public void ReturnBook_WithInvalidBook_ReturnsErrorMessage()
    {
        // Arrange
        var system = new LibraryManagementSystem();
        var member = new Member("John");
        var book = new Book("Title", "Author");
        system.RegisterMember(member);
        system.RegisterBook(book);
        system.BorrowBook(member.Id, book.Id);

        // Act
        var result = system.ReturnBook(member.Id, Guid.NewGuid());

        // Assert
        Assert.AreEqual("Book not found.", result);
    }

    [Test]
    public void ReturnBook_WithInvalidLoan_ReturnsErrorMessage()
    {
        // Arrange
        var system = new LibraryManagementSystem();
        var member = new Member("John");
        var book = new Book("Title", "Author");
        system.RegisterMember(member);
        system.RegisterBook(book);
        system.BorrowBook(member.Id, book.Id);

        // Act
        var result = system.ReturnBook(Guid.NewGuid(), Guid.NewGuid());

        // Assert
        Assert.AreEqual("Loan not found.", result);
    }

    // Increase AvailableCopies
    [Test]
    public void ReturnBook_IncreasesAvailableCopies()
    {
        // Arrange
        var system = new LibraryManagementSystem();
        var member = new Member("John");
        var book = new Book("Title", "Author");
        system.RegisterMember(member);
        system.RegisterBook(book);
        system.BorrowBook(member.Id, book.Id);

        // Act
        system.ReturnBook(member.Id, book.Id);

        // Assert
        Assert.AreEqual(1, system.GetBook(book.Id).AvailableCopies);
    }
}
