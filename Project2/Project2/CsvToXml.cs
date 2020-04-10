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
                        name = row[0];
                        surname = row[1];
                        studies = row[2];
                        studiesType = row[3];
                        number = row[4];
                        dbo = row[5];
                    }
                    {
                        string[] row = lines[1].Split(",");
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
                new XmlSerializer(typeof(Student));
            TextWriter writer = new StreamWriter(filePath_xml);

            Student s = students.ElementAt(0);
            serializer.Serialize(writer, s);
            writer.Close();

            return output;
        }
#nullable disable

        [XmlRoot]
        public class Student
        {
            //Paweł,Nowak1,Informatyka dzienne, Dzienne,459,2000-02-12
            //00:00:00.000, nowak@pjwstk.edu.pl,Alina,Adam

            [XmlAttribute]
            public string name;
            [XmlAttribute]
            public string surname;
            [XmlAttribute]
            public string studies;
            [XmlAttribute]
            public string studiesType;
            [XmlAttribute]
            public string number;
            [XmlAttribute]
            public string dbo;
            [XmlAttribute]
            public string time;
            [XmlAttribute]
            public string email;
            [XmlAttribute]
            public string n1;
            [XmlAttribute]
            public string n2;

            public Student(
                string name,
                string surname,
                string studies,
                string studiesType,
                string number,
                string dbo,
                string time,
                string email,
                string n1,
                string n2)
            {
                this.name = name;
                this.surname = surname;
                this.studies = studies;
                this.studiesType = studiesType;
                this.number = number;
                this.dbo = dbo;
                this.time = time;
                this.email = email;
                this.n1 = n1;
                this.n2 = n2;
            }

            public Student() { }

            public string ToXml()
            {
                XmlSerializer xsSubmit = new XmlSerializer(typeof(Student));
                string xml = "";

                using (var sww = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sww))
                    {
                        xsSubmit.Serialize(writer, this);
                        xml = sww.ToString();
                    }
                }

                return xml;
            }

            public string ToString()
            {
                return "Student: " + name + surname + "...";
            }
        }
    }
}
