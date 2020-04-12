using System;

namespace OOPAssignment3
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                // This is the main loop, it switches on inputted commands.
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(">: [INPUT] ");
                string userArguments = Console.ReadLine();
                string[] parsedSplitArgs = userArguments.Split(" ");
                switch (parsedSplitArgs[0].ToLower())
                {
                    case "diff":
                        var diff = new Diff(parsedSplitArgs);
                        diff.Run();
                        break;
                    case "exit":
                        var exit = new Exit(parsedSplitArgs);
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
