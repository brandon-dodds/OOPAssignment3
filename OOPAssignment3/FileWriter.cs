using System;
using System.IO;

namespace OOPAssignment3
{
    class FileWriter
    {
        private StreamWriter currentWriter { get; set; }
        // Overloading the write and writeline function to accept strings and chars.
        public void Write(char x)
        {
            currentWriter.Write(x);
        }
        public void Write(string x)
        {
            currentWriter.Write(x);
        }
        public void WriteLine(string x)
        {
            currentWriter.WriteLine(x);
        }
        public void WriteLine()
        {
            currentWriter.WriteLine();
        }
        public void WriteLine(char[] x)
        {
            currentWriter.WriteLine(x);
        }
        public void Finish()
        {
            currentWriter.Flush();
            currentWriter.Close();
        }
        public FileWriter(string filename)
        {
            currentWriter = new StreamWriter(filename);
        }
    }
}
