using System;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            CsvToXml converter = new CsvToXml(@"CsvFile.csv", @"XmlFile.xml");
            Console.WriteLine(converter.ConvertToXml());
        }
    }
}
