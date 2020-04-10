using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Project2
{
    [XmlRoot]
    public class ActiveStudy
    {
        [XmlAttribute]
        public int numberOfStudents;
        [XmlAttribute]
        public string name;

        public ActiveStudy(string name, int numberOfStudents)
        {
            this.name = name;
            this.numberOfStudents = numberOfStudents;
        }
        public ActiveStudy(string name) 
        {
            this.name = name;
        }
        public ActiveStudy() { }

        public override bool Equals(object obj)
        {
            var item = obj as ActiveStudy;
            return this.name == item.name;
        }
    }
}