namespace LibraryManagementSystem.App.Models;

public class Member
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;

    public Member(string name)
    {
        Name = name;
    }

    public Member(string name, Guid id)
    {
        Id = id;
        Name = name;
    }
}
