
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
