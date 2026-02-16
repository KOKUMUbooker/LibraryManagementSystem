using NUnit.Framework;

namespace LibraryManagementSystem.Tests;

[TestFixture]
public class TestGetMemberById
{
    [Test]
    public void TestGetMemberById()
    {
        var system = new LibraryManagementSystem();
        var id = Guid.NewGuid();
        system.AddMember("John Doe", id);
        var member = system.GetMemberById(id);
        Assert.IsNotNull(member);
        Assert.AreEqual(id, member.Id);
    }

    [Test]
    public void TestGetMemberByIdNotFound()
    {
        var system = new LibraryManagementSystem();
        var member = system.GetMemberById(2);
        Assert.IsNull(member);
    }
}
