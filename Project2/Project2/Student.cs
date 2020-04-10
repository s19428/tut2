using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Project2
{
    [XmlRoot(ElementName ="student")]
    public class Student
    {
        //Paweł,Nowak1,Informatyka dzienne, Dzienne,459,2000-02-12
        //00:00:00.000, nowak@pjwstk.edu.pl,Alina,Adam

        [XmlAttribute]
        public string indexNumber = "s";

        [XmlElement]
        public string name;
        [XmlElement]
        public string surname;

        //[XmlElement]
        //public string number;
        [XmlElement]
        public string dbo;
        [XmlElement]
        public string time;
        [XmlElement]
        public string email;
        [XmlElement]
        public string n1;
        [XmlElement]
        public string n2;

        [XmlElement]
        public Studies studies;

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
            //this.studies = studies;
            //this.studiesType = studiesType;
            this.studies = new Studies(studies, studiesType);
            this.indexNumber += number;
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

[XmlRoot]
public class Studies
{
    public Studies() { }

    public Studies(string studies, string studiesType) 
    {
        this.studies = studies;
        this.studiesType = studiesType;
    }

    [XmlElement]
    public string studies;
    [XmlElement]
    public string studiesType;
}