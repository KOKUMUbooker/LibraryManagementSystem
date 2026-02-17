namespace LibraryManagementSystem.App.Models;

public class Member
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public Member(string name, string email,Guid id)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}
