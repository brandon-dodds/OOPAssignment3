using System;
using System.IO;

namespace OOPAssignment3
{
    class FileReader
    {
        public string[] fileContents { get; set; }
        public FileReader(string filename)
        {
            try
            {
                fileContents = File.ReadAllLines(filename);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File was not found.");
            }
        }
    }
}
