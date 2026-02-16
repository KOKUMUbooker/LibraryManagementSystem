namespace LibraryManagementSystem.App.Models;

public class Book
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;

    public int TotalCopies { get; set; } = 1;
    public int AvailableCopies { get; set; } = 1;

    public Book(string title, string author, int totalCopies, Guid id)
    {
        Title = title;
        Author = author;
        TotalCopies = totalCopies;
        AvailableCopies = totalCopies;
        Id = id;
    }

    public Book(string title, string author, Guid id)
    {
        Title = title;
        Author = author;
        TotalCopies = 1;
        AvailableCopies = 1;
    }
}
