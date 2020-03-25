using System;

namespace OOPAssignment3
{
    class Exit : ICommandable
    {
        string[] Args { get; set; }
        public void Help() => Console.WriteLine("This command exits the program!");
        public void Run()
        {
            if (Args.Length == 1)
                Environment.Exit(0);
            else if (Args[1].ToLower() == "help")
                Help();
            else
                Environment.Exit(0);
        }
        public Exit(string[] args) => Args = args;
    }
}
