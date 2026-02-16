using NUnit.Framework;

namespace LibraryManagementSystem.Tests;

[TestFixture]
public class TestGetMemberByName
{
    [Test]
    public void TestGetMemberByName()
    {
        var system = new LibraryManagementSystem();
        system.AddMember("John Doe");
        var member = system.GetMemberByName("John Doe");
        Assert.IsNotNull(member);
        Assert.AreEqual("John Doe", member.Name);
    }

    [Test]
    public void TestGetMemberByNameNotFound()
    {
        var system = new LibraryManagementSystem();
        var member = system.GetMemberByName("Jane Doe");
        Assert.IsNull(member);
    }
}
