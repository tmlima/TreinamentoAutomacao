using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoAutomacao.Automation.PageObjects
{
    public class SpanPageObject
    {
        private IWebElement element;

        public SpanPageObject(IWebElement element)
        {
            this.element = element;
        }

        public string GetText()
        {
            return element.Text;
        }
    }
}
