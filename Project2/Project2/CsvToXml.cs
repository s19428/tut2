using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;

namespace Project2
{
    public class CsvToXml : Converter
    {
        string filePath_csv;
        string filePath_xml;

        /// <summary>
        /// 
        /// </summary>
        /// <param path of the file that is to be converted to xml="fielPath_csv"></param>
        /// <param destination filepath="filePath_xml"></param>
        public CsvToXml(string filePath_csv, string filePath_xml) : base(filePath_csv)
        {
            this.filePath_csv = filePath_csv;
            this.filePath_xml = filePath_xml;
        }

#nullable enable
        public string? ConvertToXml()
        {
            if (!noErrors)
                return null;

            string output = "";

            int counter = 0;
            int subCounter = 0;
            string[] lines = new string[2]; // each two lines = student record
            string line;

            List<Student> students = new List<Student>();

            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath_csv);
            while ((line = file.ReadLine()) != null)
            {
                //System.Console.WriteLine(line);
                output += line + "\n";
                counter++;
                subCounter++;
                lines[subCounter - 1] = line;
                if (subCounter == 2)
                {
                    string name;
                    string surname;
                    string studies;
                    string studiesType;
                    string number;
                    string dbo;

                    string time;
                    string email;
                    string n1;
                    string n2;

                    {
                        string[] row = lines[0].Split(",");
                        if (row.Length != 6)
                        {
                            writeToLogFile("Wrong student input format");
                            return null;
                        }
                        name = row[0];
                        surname = row[1];
                        studies = row[2];
                        studiesType = row[3];
                        number = row[4];
                        dbo = row[5];
                    }
                    {
                        string[] row = lines[1].Split(",");
                        if (row.Length != 4)
                        {
                            writeToLogFile("Wrong student input format");
                            return null;
                        }
                        time = row[0];
                        email = row[1];
                        n1 = row[2];
                        n2 = row[3];
                    }

                    students.Add(new Student(
                        name,
                        surname,
                        studies,
                        studiesType,
                        number,
                        dbo,
                        time,
                        email,
                        n1,
                        n2));
                    subCounter = 0;
                }
            }

            file.Close();

            Console.WriteLine(students.ElementAt(0).ToString());

            XmlSerializer serializer =
                new XmlSerializer(typeof(University));
            TextWriter writer = new StreamWriter(filePath_xml);

            University university = new University(students);
            //Student s = students.ElementAt(0);
            serializer.Serialize(writer, university);
            writer.Close();

            return output;
        }
#nullable disable
    }
}