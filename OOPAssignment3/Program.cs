using System;

namespace OOPAssignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(">: [INPUT] ");
                string userArguments = Console.ReadLine();
                string[] parsedSplitArgs = userArguments.Split(" ");
                switch (parsedSplitArgs[0].ToLower())
                {
                    case "diff":
                        Diff diff = new Diff(parsedSplitArgs);
                        diff.Run();
                        break;
                    case "exit":
                        Exit exit = new Exit(parsedSplitArgs);
                        exit.Run();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid command!");
                        break;
                }
            }
        }
    }
}
