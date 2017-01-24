using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoAutomacao.Automation.PageObjects;

namespace TreinamentoAutomacao.Automation.Pages
{
    public class GooglePage
    {
        private const string TextBoxSearchId = "lst-ib";

        private IWebDriver webDriver;

        private TextBoxPageObject searchBox { get { return new TextBoxPageObject( webDriver.FindElement( By.Id( TextBoxSearchId ) ) ); } }

        public GooglePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void Open()
        {
            webDriver.Url = "http://google.com";
        }

        public bool PageIsLoaded()
        {
            return webDriver.FindElements( By.Id( TextBoxSearchId ) ).Count > 0;
        }

        public void FillSearchTextBox(string text)
        {
            searchBox.Fill( text );
        }
    }
}
