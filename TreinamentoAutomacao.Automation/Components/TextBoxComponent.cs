using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoAutomacao.Automation.Components
{
    public class TextBoxPageComponent
    {
        private IWebElement element;

        public TextBoxPageComponent(IWebElement element)
        {
            this.element = element;
        }

        public void Fill(string text)
        {
            element.SendKeys( text );
        }
    }
}
