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
        private const string EvidencesDirectory = "C:\\Evidences\\";
        private ChromeDriver driver;
        private Log log;

        [ TestInitialize]
        public void Initialize()
        {
            string logFileName = "Test_" + GetTimestamp();
            log = new Log( EvidencesDirectory, logFileName );
            driver = new ChromeDriver();
        }

        [TestMethod]
        public void TestMethod1()
        {
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
