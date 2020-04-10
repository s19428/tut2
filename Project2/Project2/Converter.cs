using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project2
{
    public class Converter
    {
        public Converter(string filePath_csv)
        {
            clearLog();
            chechPath(filePath_csv);
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
            if (!IsValidPath(path, true))
            {
                writeToLogFile("Path is incorrect: " + path);
                result = false;
            }

            return result;
        }
        private bool IsValidPath(string path, bool allowRelativePaths = false)
        {
            bool isValid = true;
            try
            {
                string fullPath = Path.GetFullPath(path);
                if (allowRelativePaths)
                {
                    isValid = Path.IsPathRooted(path);
                }
                else
                {
                    string root = Path.GetPathRoot(path);
                    isValid = string.IsNullOrEmpty(root.Trim(new char[] { '\\', '/' })) == false;
                }
            }
            catch (Exception ex)
            {
                isValid = false;
            }

            return isValid;
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