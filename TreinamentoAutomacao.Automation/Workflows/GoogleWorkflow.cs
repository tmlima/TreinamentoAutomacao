using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoAutomacao.Automation.Pages;

namespace TreinamentoAutomacao.Automation.Workflows
{
    public class GoogleWorkflow
    {
        private IWebDriver webDriver;

        private GooglePage googlePage;
        private ResultsPage resultsPage;

        public GoogleWorkflow(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            this.googlePage = new GooglePage( webDriver );
            this.resultsPage = new ResultsPage( webDriver );
        }

        public void Search(string text)
        {
            googlePage.Open();
            googlePage.FillSearchTextBox( text );
            googlePage.FillSearchTextBox( Keys.Enter );
        }

        public void VerifyIfAnyResultWasFound()
        {
            resultsPage.WaitPageLoad();
            string resultStatus = resultsPage.GetResultStatus();
            Assert.IsTrue( resultStatus.Contains( "resultados" ) );
        }

        public void VerifyIfGooglePageIsUp()
        {
            googlePage.Open();
            googlePage.PageIsLoaded();
        }
    }
}
