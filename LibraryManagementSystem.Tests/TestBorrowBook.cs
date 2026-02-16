using NUnit.Framework;

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
    public void TestBorrowBook()
    {
        // Arrange
        var library = new Library();
        var member = new Member("John Doe");
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald");
        library.AddMember(member);
        library.AddBook(book);

        // Act
        var result = library.BorrowBook(member.Id, book.Id);

        // Assert
        Assert.AreEqual("Book borrowed successfully.", result);
    }

    [Test]
    public void TestBorrowBook_BookNotFound()
    {
        // Arrange
        var library = new Library();
        var member = new Member("John Doe");
        library.AddMember(member);

        // Act
        var result = library.BorrowBook(member.Id, Guid.NewGuid());

        // Assert
        Assert.AreEqual("Book not found.", result);
    }

    [Test]
    public void TestBorrowBook_NoCopiesAvailable()
    {
        // Arrange
        var library = new Library();
        var member = new Member("John Doe");
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald");
        library.AddMember(member);
        library.AddBook(book);

        // Act
        library.BorrowBook(member.Id, book.Id);
        var result = library.BorrowBook(member.Id, book.Id);

        // Assert
        Assert.AreEqual("No copies available.", result);
    }

    [Test]
    public void TestBorrowBook_MemberNotFound()
    {
        // Arrange
        var library = new Library();
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald");
        library.AddBook(book);

        // Act
        var result = library.BorrowBook(Guid.NewGuid(), book.Id);

        // Assert
        Assert.AreEqual("Member not found.", result);
    }

    [Test]
    public void TestBorrowBook_BookAlreadyBorrowedByMember()
    {
        // Arrange
        var library = new Library();
        var member = new Member("John Doe");
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald");
        library.AddMember(member);
        library.AddBook(book);

        // Act
        library.BorrowBook(member.Id, book.Id);
        var result = library.BorrowBook(member.Id, book.Id);

        // Assert
        Assert.AreEqual("Book already borrowed by this member.", result);
    }

    [Test]
    public void TestBorrowBook_BookNotFound()
    {
        // Arrange
        var library = new Library();
        var member = new Member("John Doe");
        library.AddMember(member);

        // Act
        var result = library.BorrowBook(member.Id, Guid.NewGuid());

        // Assert
        Assert.AreEqual("Book not found.", result);
    }
}
