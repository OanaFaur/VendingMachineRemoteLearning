using iQuest.VendingMachine.PresentationLayer.Commands;
using System;
using System.Collections.Generic;


namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CommandSelectorControl : DisplayBase
    {
        public IEnumerable<ICommandView> UseCases { get; set; }

        public ICommandView Display()
        {
            DisplayUseCases();
            return SelectUseCase();
        }

        private void DisplayUseCases()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Available commands:");
            Console.WriteLine();

            foreach (ICommandView useCase in UseCases)
                DisplayUseCase(useCase);
        }

        private static void DisplayUseCase(ICommandView useCase)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(useCase.Name);

            Console.ForegroundColor = oldColor;

            Console.WriteLine(" - " + useCase.Description);
        }

        private ICommandView SelectUseCase()
        {
            while (true)
            {
                string rawValue = ReadCommandName();
                ICommandView selectedUseCase = FindUseCase(rawValue);

                if (selectedUseCase != null)
                    return selectedUseCase;

                DisplayLine("Invalid command. Please try again.", ConsoleColor.Red);
            }
        }

        private ICommandView FindUseCase(string rawValue)
        {
            ICommandView selectedUseCase = null;

            foreach (ICommandView x in UseCases)
            {
                if (x.Name == rawValue)
                {
                    selectedUseCase = x;
                    break;
                }
            }

            return selectedUseCase;
        }

        private string ReadCommandName()
        {
            Console.WriteLine();
            Display("Choose command: ", ConsoleColor.Cyan);
            string rawValue = Console.ReadLine();
            Console.WriteLine();

            return rawValue;
        }
    }
}