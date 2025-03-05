
namespace UIAPIAutomationTests.Libraries
{
    public class FirefoxDriverFactory : IWebDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            return new FirefoxDriver();
        }
    }
}
