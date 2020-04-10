using System;

namespace OOPAssignment3
{
    class Exit : ICommandable
    {
        private string[] Args { get; set; }
        public string Help()
        {
            return "This command exits the program!";
        }
        public void Run()
        {
            if (Args.Length == 1)
                Environment.Exit(0);
            else if (Args[1].ToLower() == "help")
                Console.WriteLine(Help());
            else
                Environment.Exit(0);
        }
        public Exit(string[] args) => Args = args;
    }
}
