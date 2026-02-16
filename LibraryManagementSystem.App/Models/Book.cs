namespace LibraryManagementSystem.App.Models;

public class Book
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;

    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
}
