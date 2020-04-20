using System;

namespace OOPAssignment3
{
    class Exit : Command
    {
        //Override both the Help and Run functions inherited by Command.
        protected override string Help()
        {
            return "This command exits the program!";
        }
        public override void Run()
        {
            if (Args.Length == 1)
                Environment.Exit(0);
            else if (Args[1].ToLower() == "help")
                Console.WriteLine(Help());
            else
                Environment.Exit(0);
        }
        public Exit(string[] args)
        {
            // Assign arguments.
            Args = args;
        }
    }
}
