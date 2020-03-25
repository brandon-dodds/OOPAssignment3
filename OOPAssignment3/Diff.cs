using System;
using System.Collections.Generic;
namespace OOPAssignment3
{
    class Diff : ICommandable
    {
        string[] Args { get; set; }
        public void Help() => Console.WriteLine("Please enter: diff [text1] [text2]");
        private int[] DiffLines()
        {
            FileReader file1 = new FileReader(Args[1]);
            FileReader file2 = new FileReader(Args[2]);
            List<int> changedLineNumbers = new List<int>();
            for(int i = 0; i < file1.fileContents.Length; i++)
            {
                if (file1.fileContents[i] != file2.fileContents[i])
                {
                    Console.WriteLine($"Line {i + 1} is different.");
                    changedLineNumbers.Add(i);
                }
            }
            return changedLineNumbers.ToArray();
        }
        public void Run()
        {
            if (Args.Length == 1)
                Console.WriteLine("You have entered the diff command! Enter arguments to use this command.");
            else if (Args[1].ToLower() == "help")
                Help();
            else if (Args.Length == 3)
                Console.WriteLine(DiffLines()); 
            else
                Console.WriteLine("Diff requires exactly two arguments!");
        }
        public Diff(string[] args) => Args = args;
    }
}
