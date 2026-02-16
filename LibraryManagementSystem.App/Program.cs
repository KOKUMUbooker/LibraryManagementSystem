using LibraryManagementSystem.App.Services;

namespace LibraryManagementSystem.App;

class Program
{
    static void Main(string[] args)
    {
        var service = new LibraryService();
        var ui = new ConsoleUI(service);
        ui.Run();
    }
}
