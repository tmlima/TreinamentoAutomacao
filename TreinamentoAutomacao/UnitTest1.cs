using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace TreinamentoAutomacao
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Url = "http://google.com";
            IWebElement searchField = driver.FindElementById( "lst-ib" );
            searchField.SendKeys( "Automation" );
            searchField.SendKeys( Keys.Enter );
        }
    }
}
