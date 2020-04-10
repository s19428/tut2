using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project2
{
    public class Converter
    {
        public bool noErrors = true;
        public Converter(string filePath_csv)
        {
            clearLog();
            noErrors = chechPath(filePath_csv);
        }

        private const string logFile = @"log.txt";
        public bool chechPath(string path)
        {
            bool result = true;
            if (!File.Exists(path))
            {
                writeToLogFile("File does not exist: " + path);
                result = false;
            }
            else
            {
                if (!IsValidPath(path))
                {
                    writeToLogFile("Path is incorrect: " + path);
                    result = false;
                }
            }

            return result;
        }
        private bool IsValidPath(string path)
        {
            FileAttributes attr = File.GetAttributes(path);
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                return false; // Its a directory

            return true;
        }

        public void writeToLogFile(string text)
        {
            TextWriter tsw = new StreamWriter(logFile, true);
            tsw.WriteLine(text);
            tsw.Close();

            Console.WriteLine("Error occured: " + text);
        }

        public void clearLog()
        {
            if (File.Exists(logFile))
                File.WriteAllText(logFile, String.Empty);
        }
    }
}