using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Project2
{
    [XmlRoot]
    public class University
    {
        [XmlArray(ElementName = "students")]
        public List<Student> students;

        public University(List<Student> students) 
        {
            this.students = students;
        }
        public University() { }
    }
}
