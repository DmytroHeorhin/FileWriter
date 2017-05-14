using System;
using System.IO;

namespace Convestudo.Unmanaged
{
    class Program
    {
        private static void Main(string[] args)
        {
            var testFileName = "log.txt";
            using (var fileWriter = new FileWriter(testFileName))
            {
                Console.WriteLine("Writing first time...");
                fileWriter.Write("First ");
                fileWriter.Write("test string");
            }

            using (var streamReader = new StreamReader(testFileName))
            {
                Console.WriteLine(streamReader.ReadToEnd());
            }
        }
    }
}
