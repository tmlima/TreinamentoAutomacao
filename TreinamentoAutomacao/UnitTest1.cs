using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Drawing.Imaging;
using System.Threading;
using OpenQA.Selenium.Support.UI;

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

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
        }

        [TestMethod]
        public void VerifySearchResults()
        {
            log.Write( "Going to http://google.com" );
            driver.Url = "http://google.com";

            //IWebElement searchField = driver.FindElementById( "lst-ib" );
            IWebElement searchField = driver.FindElementByXPath( "//input[@id='lst-ib']" );

            log.Write( "Writing searchText" );
            searchField.SendKeys( "Automation" );

            log.Write( "Clicking enter" );
            searchField.SendKeys( Keys.Enter );

            WebDriverWait wait = new WebDriverWait( driver, TimeSpan.FromSeconds( 5 ) );
            IWebElement resultStatus = wait.Until( x => x.FindElement( By.Id( "resultStats" ) ) );
            Assert.IsTrue( resultStatus.Text.Contains( "resultados" ) );

            log.Write( "Taking screenshot" );
            Screenshot googleResults = driver.GetScreenshot();
            googleResults.SaveAsFile( EvidencesDirectory + GetTimestamp() + ".jpeg", ImageFormat.Jpeg );
            log.Save();
        }

        [TestMethod]
        public void GoogleSearchIsAlive()
        {
            log.Write( "Going to http://google.com" );
            driver.Url = "http://google.com";

            log.Write( "Taking screenshot" );
            Screenshot googleResults = driver.GetScreenshot();
            googleResults.SaveAsFile( EvidencesDirectory + GetTimestamp() + ".jpeg", ImageFormat.Jpeg );
            Assert.IsNotNull( driver.FindElementById( "lst-ib" ) );
            log.Save();
        }

        private string GetTimestamp()
        {
            return DateTime.Now.ToString( "yyyyMMdd_hhmmss" );
        }

    }
}
