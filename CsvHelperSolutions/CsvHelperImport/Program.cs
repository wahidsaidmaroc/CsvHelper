using CsvHelper;
using CsvHelper.Configuration;
using System.Data;
using System.Formats.Asn1;
using System.Globalization;
using System.Text;

namespace CsvHelperImport
{
    internal class Program
    {
        static void Main(string[] args)
        {
         
            //Configuration 
            var config = new CsvConfiguration(CultureInfo.CurrentCulture)
            { Delimiter = ";", Encoding = Encoding.Latin1 };

            //Read File by Stream Reader
            using (var reader = new StreamReader("File.csv"))

            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<Personn>();
                foreach (var item in records)
                {
                    Console.WriteLine(item.Address);
                }
            }

          
        }
    }

    public class Personn
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }

}