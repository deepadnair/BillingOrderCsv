using BillingOrderCsv.BillingOrderPage;
using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.IO;
using System.Net;

namespace BillingOrderCsv
{
    public class Tests
    {
        IWebDriver driver;
        LoginPage login = new LoginPage();



        [SetUp]
        public void Setup()
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://qaauto.co.nz/billing-order-form/");
            driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Dispose();
        }
        [Test]
        public void Test1()
        {
            login.Login(driver);
         //  BillngOrdr billing = new BillngOrdr(driver);

          /*   billing.BillngOrdr("Ajay",
                                    "Kisho", 
                                    "fhoughsgh",
                                    "lfjblkdfgl", 
                                    "AL",
                                    "hgshsdsjfsigvjs",
                                    "ajay@gmail.com",
                                    1,
                                    "1234567890",
                                    "AL",
                                   "123456");*/


        }
        [TestCaseSource("CsvExample1")]


        public void TC3(BillngOrdr ordr)
        {
            TestContext.WriteLine(ordr.firstName);
           
        }
        
        static string csvPath2 = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\testData\\data.csv";
        static string csvPath3 = "C:\\Users\\kisho\\source\\repos\\BillingOrderCsv\\BillingOrderCsv\\TestData\\data.csv";
        public static IEnumerable CsvExample1()
        {
            using (var csv = new CsvReader(new StreamReader(Path.Combine(csvPath3)), true))
            {
                while (csv.ReadNextRecord())
                {
                    yield return new TestCaseData(new BillngOrdr(csv["firstName"], csv["lastName"], csv["addressLine1"], csv["addressLine2"], csv["city"], csv["comment"], csv["email"], csv["itemnumber"], csv["phone"], csv["state"], csv["zipCode"]));
                }


            }


        }

    }
}

    



