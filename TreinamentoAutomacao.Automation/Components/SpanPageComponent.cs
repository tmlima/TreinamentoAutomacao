using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoAutomacao.Automation.Components
{
    public class SpanPageComponent
    {
        private IWebElement element;

        public SpanPageComponent(IWebElement element)
        {
            this.element = element;
        }

        public string GetText()
        {
            return element.Text;
        }
    }
}
