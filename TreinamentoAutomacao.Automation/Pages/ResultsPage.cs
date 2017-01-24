using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoAutomacao.Automation.PageObjects;

namespace TreinamentoAutomacao.Automation.Pages
{
    public class ResultsPage
    {
        private const string SpanResultStatusId = "resultStats";

        private IWebDriver webDriver;

        private SpanPageObject resultStatus { get { return new SpanPageObject( webDriver.FindElement( By.Id( SpanResultStatusId ) ) ); } }

        public ResultsPage( IWebDriver webDriver )
        {
            this.webDriver = webDriver;
        }

        public void WaitPageLoad()
        {
            WebDriverWait wait = new WebDriverWait( webDriver, TimeSpan.FromSeconds( 5 ) );
            IWebElement resultStatus = wait.Until( x => x.FindElement( By.Id( SpanResultStatusId ) ) );
        }

        public string GetResultStatus()
        {
            return resultStatus.GetText();
        }
    }
}
