namespace LibraryManagementSystem.App.Models;

public class Loan
{
    public Guid BookId { get; set; }
    public Guid MemberId { get; set; }
    public string MemberEmail { get; set; }
    public DateTime BorrowDate { get; set; } = DateTime.UtcNow;

    public Loan(Guid bookId, string memberEmail, Guid memberId)
    {
        BookId = bookId;
        MemberId = memberId;
        MemberEmail = memberEmail;
    }
}
