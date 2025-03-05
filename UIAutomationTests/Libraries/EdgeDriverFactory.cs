using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAPIAutomationTests.Libraries
{
    public class EdgeDriverFactory : IWebDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            return new EdgeDriver();
        }

    }
}
