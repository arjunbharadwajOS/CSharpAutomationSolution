namespace SpecflowUIAutomation.Libraries
{
    public class WebDriverFactory
    {
        public static IWebDriver GetWebDriver(BrowserType browserType)
        {
            switch (browserType)
            {                                                                               
                case BrowserType.Chrome:
                    return new ChromeDriverFactory().CreateDriver();
                case BrowserType.Firefox:
                    return new FirefoxDriverFactory().CreateDriver();
                case BrowserType.Edge:
                    return new EdgeDriverFactory().CreateDriver();
                default:
                    throw new ArgumentException("Unsupported browser type.");
            }
        }
    }
}
