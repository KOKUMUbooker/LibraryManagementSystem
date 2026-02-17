namespace LibraryManagementSystem.Tests;

using NUnit.Framework;
using NUnit.Framework.Legacy;
using LibraryManagementSystem.App.Services;

[TestFixture]
public class TestGetMemberByName
{
    private LibraryService _libraryService = null!;

    [SetUp]
    public void Setup()
    {
        _libraryService = new LibraryService();
    }

    [Test]
    public void GetMemberByName_ShouldReturnMemberForExistingName()
    {
        var name = "Levi Ackerman";
        _libraryService.RegisterMember(name,"levi@gmail.com",Guid.NewGuid());
        var member = _libraryService.GetMemberByName(name);
        ClassicAssert.IsNotNull(member);
        ClassicAssert.AreEqual(name, member?.Name);
    }

    [Test]
    public void TestGetMemberByNameNotFound()
    {
        var member = _libraryService.GetMemberByName("Bertholdt Hoover");
        ClassicAssert.IsNull(member);
    }
}
