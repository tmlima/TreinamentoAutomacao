using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoAutomacao.Automation.Components
{
    public class TextBoxComponent
    {
        private IWebElement element;

        public TextBoxComponent(IWebElement element)
        {
            this.element = element;
        }

        public void Fill(string text)
        {
            element.SendKeys( text );
        }
    }
}
