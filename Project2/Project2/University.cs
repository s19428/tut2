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
        [XmlArray(ElementName = "activeStudies")]
        public List<ActiveStudy> activeStudies;
        public University(List<Student> students, List<ActiveStudy> activeStudies) 
        {
            this.students = students;
            this.activeStudies = activeStudies;
        }
        public University() { }
    }
}