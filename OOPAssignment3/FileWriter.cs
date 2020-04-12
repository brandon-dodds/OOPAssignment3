using System.IO;

namespace OOPAssignment3
{
    class FileWriter
    {
        private StreamWriter CurrentWriter { get; set; }
        // Overloading the write and writeline function to accept strings and chars.
        public void Write(char x)
        {
            CurrentWriter.Write(x);
        }
        public void Write(string x)
        {
            CurrentWriter.Write(x);
        }
        public void WriteLine(string x)
        {
            CurrentWriter.WriteLine(x);
        }
        public void WriteLine()
        {
            CurrentWriter.WriteLine();
        }
        public void Finish()
        {
            CurrentWriter.Flush();
            CurrentWriter.Close();
        }
        public FileWriter(string filename)
        {
            CurrentWriter = new StreamWriter(filename);
        }
    }
}
