using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoAutomacao.Automation.Components
{
    public class SpanComponent
    {
        private IWebElement element;

        public SpanComponent(IWebElement element)
        {
            this.element = element;
        }

        public string GetText()
        {
            return element.Text;
        }
    }
}
