namespace LibraryManagementSystem.App.Models;

public class Loan
{
    public Guid BookId { get; set; }
    public Guid MemberId { get; set; }
    public DateTime BorrowDate { get; set; } = DateTime.UtcNow;
}
