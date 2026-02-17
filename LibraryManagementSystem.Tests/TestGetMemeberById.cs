namespace LibraryManagementSystem.Tests;

using NUnit.Framework;
using NUnit.Framework.Legacy;
using LibraryManagementSystem.App.Services;

[TestFixture]
public class TestGetMemberById
{
    private LibraryService _libraryService = null!;

    [SetUp]
    public void Setup()
    {
        _libraryService = new LibraryService();
    }

    [Test]
    public void GetMemberById_ShouldReturnMember()
    {
        var id = Guid.NewGuid();
        _libraryService.RegisterMember("John Doe","jdoe@email",id);
        var member = _libraryService.GetMemberById(id);
        ClassicAssert.IsNotNull(member);
        ClassicAssert.AreEqual(id, member?.Id);
    }

    [Test]
    public void GetMemberById_ShouldReturnNullIfMemberDoesNotExist ()
    {
        var id = Guid.NewGuid();
        var member = _libraryService.GetMemberById(id);
        ClassicAssert.IsNull(member);
    }
}
