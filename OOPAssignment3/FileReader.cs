using System;
using System.IO;

namespace OOPAssignment3
{
    class FileReader
    {
        public string[] FileContents { get; set; }
        public FileReader(string filename)
        {
            try
            {
                FileContents = File.ReadAllLines(filename);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File was not found.");
            }
        }
    }
}
