using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VendingMachine.Tests")]
namespace iQuest.VendingMachine.PresentationLayer
{
    internal class LoginView : DisplayBase, ILoginView
    {
        public string AskForPassword()
        {
            Console.WriteLine();
            Display("Type the admin password: ", ConsoleColor.Cyan);
            return Console.ReadLine();
        }
    }
}