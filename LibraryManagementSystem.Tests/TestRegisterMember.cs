namespace LibraryManagementSystem.Tests;

using NUnit.Framework;
using NUnit.Framework.Legacy;
using LibraryManagementSystem.App.Models;
using LibraryManagementSystem.App.Services;

// public Member RegisterMember(string name)
// Should
// Create member
// Add to _members
// Return it

[TestFixture]
public class TestRegisterMember
{
    private LibraryService _libraryService = null!;

    [SetUp]
    public void Setup()
    {
        _libraryService = new LibraryService();
    }

    [Test]
    public void RegisterMember_ShouldCreateMember()
    {
        // Arrange
        var member = new Member("John",Guid.NewGuid());

        // Act
        var result = _libraryService.RegisterMember(member.Name,member.Id);

        // Assert
        ClassicAssert.AreEqual(member.Id, result.Id);
    }

    [Test]
    public void RegisterMember_ShouldRegisterMemberToMembers()
    {
        // Arrange
        var member = new Member("John",Guid.NewGuid());

        // Act
        var registeredMember = _libraryService.RegisterMember(member.Name,member.Id);

        // Assert
        ClassicAssert.Contains(registeredMember, _libraryService.GetAllMembers());
    }
}
