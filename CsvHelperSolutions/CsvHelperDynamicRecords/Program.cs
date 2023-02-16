using CsvHelper;
using System.Globalization;

namespace CsvHelperDynamicRecords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("File.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>();
          

                foreach (var item in records)
                {
                    var obj = item;
                }
            }
        }
    }
}