using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Drawing.Imaging;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using TreinamentoAutomacao.Automation.Workflows;

namespace TreinamentoAutomacao
{
    [TestClass]
    public class GoogleTests
    {
        private const string EvidencesDirectory = "C:\\Evidences\\";
        private ChromeDriver driver;
        private Log log;
        private GoogleWorkflow googleWorkflow;

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [ TestInitialize]
        public void Initialize()
        {
            string logFileName = "Test_" + GetTimestamp();
            log = new Log( EvidencesDirectory, logFileName );
            driver = new ChromeDriver();
            googleWorkflow = new GoogleWorkflow( driver );
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
        }

        [TestMethod]
        [DataSource( "Microsoft.VisualStudio.TestTools.DataSource.CSV", "C:\\TestData\\", "googletest#csv", DataAccessMethod.Sequential )]
        public void VerifySearchResults()
        {
            string searchText = TestContext.DataRow[ "SearchText" ].ToString();

            googleWorkflow.Search( searchText );
            googleWorkflow.VerifyIfAnyResultWasFound();
        }

        [TestMethod]
        public void GoogleSearchIsAlive()
        {
            googleWorkflow.VerifyIfGooglePageIsUp();
        }

        private string GetTimestamp()
        {
            return DateTime.Now.ToString( "yyyyMMdd_hhmmss" );
        }

    }
}
