using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Drawing.Imaging;

namespace TreinamentoAutomacao
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string EvidencesDirectory = "C:\\Evidences\\";
            string logFileName = "Test_" + GetTimestamp();
            Log log = new Log( EvidencesDirectory, logFileName );
            ChromeDriver driver = new ChromeDriver();

            log.Write( "Going to http://google.com" );
            driver.Url = "http://google.com";

            IWebElement searchField = driver.FindElementById( "lst-ib" );
            log.Write( "Writing searchText" );
            searchField.SendKeys( "Automation" );

            log.Write( "Clicking enter" );
            searchField.SendKeys( Keys.Enter );

            log.Write( "Taking screenshot" );
            Screenshot googleResults = driver.GetScreenshot();
            googleResults.SaveAsFile( EvidencesDirectory + GetTimestamp() + ".jpeg", ImageFormat.Jpeg );
            log.Save();
        }

        private string GetTimestamp()
        {
            return DateTime.Now.ToString( "yyyyMMdd_hhmmss" );
        }

    }
}
