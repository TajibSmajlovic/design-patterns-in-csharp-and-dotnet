using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SingleResponsibilityPrinciple
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static ushort count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");

            return count; // memento pattern
        }

        public void RemoveEntry(ushort index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistance
    {
        public void SaveToFile(Journal journal, string fileName, bool overwrite = false)
        {
            if (overwrite || !File.Exists(fileName))
            {
                File.WriteAllText(fileName, journal.ToString());
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var journal = new Journal();
            journal.AddEntry("First entry");
            journal.AddEntry("Second entry");

            Console.WriteLine(journal);

            var persistance = new Persistance();
            var fileName = @"C:\Users\smajl\Documents\Tajib\Programming\journal.txt";
            persistance.SaveToFile(journal, fileName, true);
        }
    }
}