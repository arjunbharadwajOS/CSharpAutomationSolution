

namespace SpecflowUIAutomation.Libraries
{
    public class ChromeDriverFactory : IWebDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            return new ChromeDriver();
        }
    }
 
}
