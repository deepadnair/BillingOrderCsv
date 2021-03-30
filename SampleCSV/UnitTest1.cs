using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;
using System;
using System.Collections;
using System.IO;

namespace SampleCSV
{
    
    public class Tests
    {

        [Category("CSVExample")]
        [TestCaseSource("CSVDATA")]
        public void TestingCSVData(string firstName, string email)
        {
            TestContext.WriteLine(firstName);
        }

        
        static string csvPath = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\TestData1\\forms.csv";
        static string csvPath1 = "C:\\Users\\kisho\\source\\repos\\BillingOrderCsv\\SampleCSV\\TestData1\\forms.csv";
        public static IEnumerable CSVDATA()
        {
            using (var csv = new CsvReader(new StreamReader(Path.Combine(csvPath1)), true))
            {
                while (csv.ReadNextRecord())
                {
                    yield return new[] { csv["firstName"], csv["email"] };
                }
            }
        }
    }
}