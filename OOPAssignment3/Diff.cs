﻿using System;

namespace OOPAssignment3
{
    class Diff : Command
    {
        // The Args[] field is inherited.
        private string[] FormerFile { get; set; }
        private string[] LatterFile { get; set; }
        private void DiffLines()
        {
            bool areFilesDifferent = false;
            FileWriter fileWriter = new FileWriter("log.txt");
            for (int i = 0; i < FormerFile.Length || i < LatterFile.Length; i++)
            {
                Console.WriteLine($"Line {i + 1}");
                fileWriter.WriteLine($"Line {i + 1}");
                // Starts with Line 0 up to the larger file size length.
                /* Two line pointers are created.
                 * They are null by default.
                 * If the index is in range for the file, the pointer becomes that line.
                 */
                string formerLinePointer, latterLinePointer = formerLinePointer = null;
                if (i < FormerFile.Length)
                    formerLinePointer = FormerFile[i];
                if (i < LatterFile.Length)
                    latterLinePointer = LatterFile[i];
                // If both the char arrays hold characters.
                if (formerLinePointer != null && latterLinePointer != null)
                {
                    //First for loop shows subtractions.
                    Console.Write("-: ");
                    fileWriter.Write("-: ");
                    for (int j = 0; j < formerLinePointer.Length || j < latterLinePointer.Length; j++)
                    {
                        /* Create the specific char.
                         * if the char index is in range, assign it to the indexed value of the char array
                         */
                        char formerCharPointer, latterCharPointer = formerCharPointer = default;
                        if (j < formerLinePointer.Length)
                            formerCharPointer = formerLinePointer[j];
                        if (j < latterLinePointer.Length)
                            latterCharPointer = latterLinePointer[j];
                        // If the formerCharPointer isn't null, and the first one is or they arent the same, class it as a subtraction.
                        if (formerCharPointer != '\0' && latterCharPointer == '\0' || formerCharPointer != latterCharPointer)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(formerCharPointer);
                            fileWriter.Write(formerCharPointer);
                            areFilesDifferent = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(formerCharPointer);
                            fileWriter.Write(formerCharPointer);
                        }
                    }
                    Console.WriteLine();
                    fileWriter.WriteLine();
                    Console.ResetColor();
                    // Second for loop shows additions.
                    Console.Write("+: ");
                    fileWriter.Write("+: ");
                    for (int j = 0; j < formerLinePointer.Length || j < latterLinePointer.Length; j++)
                    {
                        /* Create the specific char.
                         * if the char index is in range, assign it to the indexed value of the char array
                         */
                        char formerCharPointer, latterCharPointer = formerCharPointer = default;
                        if (j < formerLinePointer.Length)
                            formerCharPointer = formerLinePointer[j];
                        if (j < latterLinePointer.Length)
                            latterCharPointer = latterLinePointer[j];
                        // If the formerCharPointer is null, and the second one isn't or they arent the same, class it as an addition.
                        if (formerCharPointer == '\0' && latterCharPointer != '\0' || formerCharPointer != latterCharPointer)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(latterCharPointer);
                            fileWriter.Write(latterCharPointer);
                            areFilesDifferent = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(formerCharPointer);
                            fileWriter.Write(formerCharPointer);
                        }
                    }
                    Console.WriteLine();
                    fileWriter.WriteLine();
                }
                // If formerCharArray is null and latterCharArray is not null, stuff has been added.
                else if (formerLinePointer == null && latterLinePointer != null)
                {
                    Console.Write("+: ");
                    fileWriter.Write("+: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(latterLinePointer);
                    fileWriter.WriteLine(latterLinePointer);
                    areFilesDifferent = true;
                }
                // If formerCharArray is not null and latterCharArray is null, stuff has been removed.
                else if (formerLinePointer != null && latterLinePointer == null)
                {
                    Console.Write("-: ");
                    fileWriter.Write("-: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(formerLinePointer);
                    fileWriter.WriteLine(formerLinePointer);
                    areFilesDifferent = true;
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (areFilesDifferent)
            {
                Console.WriteLine("These files are different");
                fileWriter.WriteLine("These files are different");
            }
            else
            {
                Console.WriteLine("These files are the same.");
                fileWriter.WriteLine("These files are the same.");
            }
            fileWriter.Finish();
        }
        protected override string Help()
        {
            return "Please enter: diff [text1] [text2]";
        }
        public override void Run()
        {
            //Generate the specific outcome depending on the arguments given during function creation.
            if (Args.Length == 1)
            {
                Console.WriteLine("You have entered the diff command! Enter arguments to use this command.");
            }
            else if (Args[1].ToLower() == "help")
            {
                Console.WriteLine(Help());
            }
            else if (Args.Length == 3)
            {
                FormerFile = new FileReader(Args[1]).FileContents;
                LatterFile = new FileReader(Args[2]).FileContents;
                if (FormerFile == null || LatterFile == null)
                {
                    Console.WriteLine("The files entered need to exist!");
                }
                else
                {
                    DiffLines();
                }
            }
            else
            {
                Console.WriteLine("Diff requires exactly two arguments!");
            }
        }
        public Diff(string[] args)
        {
            //Assign the arguments passed into the arguments field inherited by Command.
            Args = args;
        }
    }
}
