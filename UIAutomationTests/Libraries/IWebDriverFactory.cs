using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAPIAutomationTests.Libraries
{
    public interface IWebDriverFactory
    {
        IWebDriver CreateDriver();
    }
}
