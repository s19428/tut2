using System;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = @"data.csv";
            string result = @"result.xml";
            string targetFormat = "xml";
            if (args.Length == 3)
            {
                data = args[0];
                result = args[1];
                targetFormat = args[2];

                // We assume that the only target format is xml
                CsvToXml converter = null;
                if (targetFormat == "xml")
                    converter = new CsvToXml(data, result);
                Console.WriteLine(converter.ConvertToXml());
            }
            else
            {
                CsvToXml converter = new CsvToXml(data, result);
                Console.WriteLine(converter.ConvertToXml());
            }
        }
    }
}