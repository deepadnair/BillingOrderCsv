using BillingOrderCsv.BillingOrderPage;
using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BillingOrderCsv
{
   public class ICCSVExample
    {

        [TestCaseSource("CsvExample")]

        public void TC2(string firstName,string lastname, string addressLine1, string addressLine2, string city,string comment,string email, string itemnumber, string phone,string state, string zipCode)
        {
           // BillngOrdr billing1 = new BillngOrdr();
            TestContext.WriteLine(firstName);
        }

        static string csvPath = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\testData\\data.csv";
        static string csvPath1 = "C:\\Users\\kisho\\source\\repos\\BillingOrderCsv\\BillingOrderCsv\\TestData\\data.csv";
        public static IEnumerable CsvExample()
        {
            using (var csv = new CsvReader(new StreamReader(Path.Combine(csvPath1)), true))
            {
                while (csv.ReadNextRecord())
                {
                    yield return new TestCaseData(csv["firstName"], csv["lastName"], csv["addressLine1"], csv["addressLine2"], csv["city"], csv["comment"], csv["email"], csv["itemnumber"], csv["phone"], csv["state"], csv["zipCode"]);
                }


            }


        }

        
    }
}
