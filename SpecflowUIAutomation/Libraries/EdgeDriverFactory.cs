

namespace SpecflowUIAutomation.Libraries
{
    public class EdgeDriverFactory : IWebDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            return new EdgeDriver();
        }

    }
}
