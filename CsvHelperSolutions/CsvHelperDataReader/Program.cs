using CsvHelper;
using CsvHelper.Configuration;
using System.Data;
using System.Globalization;
using System.Text;

namespace CsvHelperDataReader
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
                // Do any configuration to `CsvReader`
                // before creating CsvDataReader.
                using (var dr = new CsvDataReader(csv))
                {
                    var dt = new DataTable();
                    dt.Load(dr);
                    var obj = GetDict(dt);
                }
            }

        }


        static Dictionary<string, object> GetDict(DataTable dt)
        {
            return dt.AsEnumerable()
              .ToDictionary<DataRow, string, object>(row => row.Field<string>(0),
                                        row => row.Field<object>(1));
        }
    }


}