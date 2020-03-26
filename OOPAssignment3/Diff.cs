using System;
namespace OOPAssignment3
{
    class Diff : ICommandable
    {
        private string[] Args { get; set; }
        private string[] formerFile { get; set; }
        private string[] latterFile { get; set; }
        
        private void DiffLines()
        {
            string[] formerLinePointer = default;
            string[] latterLinePointer = default;
        }
        public void Help() => Console.WriteLine("Please enter: diff [text1] [text2]");
        public void Run()
        {
            if (Args.Length == 1)
                Console.WriteLine("You have entered the diff command! Enter arguments to use this command.");
            else if (Args[1].ToLower() == "help")
                Help();
            else if (Args.Length == 3)
            {
                formerFile = new FileReader(Args[1]).fileContents;
                latterFile = new FileReader(Args[2]).fileContents;
                DiffLines();
            }
            else
                Console.WriteLine("Diff requires exactly two arguments!");
        }
        public Diff(string[] args) => Args = args;
    }
}
