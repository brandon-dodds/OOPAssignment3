using System;
using System.Collections.Generic;
using System.Linq;
namespace OOPAssignment3
{
    class Diff : ICommandable
    {
        private string[] Args { get; set; }
        private string[] FormerFile { get; set; }
        private string[] LatterFile { get; set; }

        private void DiffLines()
        {
            // Determines the larger file size.
            int largerFileSize = FormerFile.Length;
            if (FormerFile.Length < LatterFile.Length)
                largerFileSize = LatterFile.Length;

            for (int i = 0; i < largerFileSize; i++)
            {
                Console.WriteLine($"Line {i + 1}");
                // Starts with Line 0 up to the larger file size length.
                /* Two line pointers are created.
                 * They are null by default.
                 * If the index is in range for the file, the pointer becomes that line.
                 */
                string formerLinePointer = null;
                if (i < FormerFile.Length)
                    formerLinePointer = FormerFile[i];
                string latterLinePointer = null;
                if (i < LatterFile.Length)
                    latterLinePointer = LatterFile[i];

                /* A char array is created.
                 * if the line pointers are not null, then the char array = the specific line.
                 */
                char[] formerCharArray = null;
                char[] latterCharArray = null;
                if (formerLinePointer != null)
                    formerCharArray = formerLinePointer.ToCharArray();
                if (latterLinePointer != null)
                    latterCharArray = latterLinePointer.ToCharArray();

                List<char> same = new List<char>();
                List<char> additions = new List<char>();
                List<char> subtractions = new List<char>();
                //if both the char arrays are not null (they have text)
                if (formerCharArray != null && latterCharArray != null)
                {
                    // Figure out the larget line size. (character lengths).
                    int largerLineSize = formerCharArray.Length;
                    if (formerCharArray.Length < latterCharArray.Length)
                        largerLineSize = latterCharArray.Length;

                    for (int j = 0; j < largerLineSize; j++)
                    { 
                        /* Create the specific char.
                         * if the char index is in range, assign it to the indexed value of the char array
                         */
                        char formerCharPointer = default;
                        if (j < formerCharArray.Length)
                            formerCharPointer = formerCharArray[j];
                        char latterCharPointer = default;
                        if (j < latterCharArray.Length)
                            latterCharPointer = latterCharArray[j];
                        // If the chars are equal, then print normally.
                        if (formerCharPointer == latterCharPointer)
                            same.Add(formerCharPointer);
                        // If the former char pointer is not null, and the latter is null, show it as removed.
                        else if (formerCharPointer != '\0' && latterCharPointer == '\0')
                        {
                            subtractions.Add(formerCharPointer);
                        }
                        else
                        {
                            subtractions.Add(formerCharPointer);
                            additions.Add(latterCharPointer);
                        }
                    }
                }
                if (formerCharArray == null && latterCharArray != null)
                    additions = latterCharArray.ToList();
                if (formerCharArray != null && latterCharArray == null)
                    subtractions = formerCharArray.ToList();
                
                Console.Write("- ");
                Console.Write(new string(same.ToArray()));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(new string(subtractions.ToArray()));
                Console.WriteLine();
                Console.ResetColor();

                Console.Write("+ ");
                Console.Write(new string(same.ToArray()));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(new string(additions.ToArray()));
                Console.WriteLine();
                Console.ResetColor();
            }
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
                FormerFile = new FileReader(Args[1]).fileContents;
                LatterFile = new FileReader(Args[2]).fileContents;
                if (FormerFile == null || LatterFile == null)
                    Console.WriteLine("The files entered need to exist!");
                else
                    DiffLines();
            }
            else
                Console.WriteLine("Diff requires exactly two arguments!");
        }
        public Diff(string[] args) => Args = args;
    }
}
