using NUnit.Framework;

// public Member RegisterMember(string name)
// Should
// Create member
// Add to _members
// Return it

[TestFixture]
public class TestRegisterMember
{
    [Test]
    public void ShouldCreateMember()
    {
        // Arrange
        var system = new LibraryManagementSystem();
        var member = new Member("John");

        // Act
        var result = system.RegisterMember(member,);

        // Assert
        Assert.AreEqual(member, result);
    }

    [Test]
    public void ShouldAddMemberToMembers()
    {
        // Arrange
        var system = new LibraryManagementSystem();
        var member = new Member("John");

        // Act
        var result = system.RegisterMember(member);

        // Assert
        Assert.Contains(member, system.Members);
    }
}
