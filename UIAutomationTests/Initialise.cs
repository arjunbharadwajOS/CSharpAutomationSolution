

using static UIAPIAutomationTests.Libraries.WebDriverFactory;
using UIAPIAutomationTests.Libraries;

namespace UIAPIAutomationTests
{
    public enum BrowserType
    {
        Chrome,
        Firefox,
        Edge
    }

    public enum TestStatus
    {
        Pass,
        Fail,
        Skip
    }

    public class Initialise
    {
        private static Initialise _instance;
        public IWebDriver driver = null;
        public HomePage hpage = null;
        public Reports reports = null;
        public APIMethods apiMethods = null;

        private Initialise()
        {
            
        }

        public static Initialise Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Initialise();

                return _instance;
            }
        }

        public string getProjectPath()
        {
            string path = Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;

            string reportPath = projectPath + "Reports\\";
            return reportPath;
        }

 
        public void setup(string urlString, BrowserType browserType)
        {

            driver = WebDriverFactory.GetWebDriver(browserType);

            driver.Navigate().GoToUrl(urlString);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
        }

        public void pageClasses()
        {
            hpage = new HomePage(driver, reports);
        }

        public void getReportClass()
        {
            reports = new Reports();
        }

        public void getAPIMethodClass()
        {
            apiMethods = new APIMethods();
        }

       
        public void tearDown()
        {
            driver.Quit();
        }

        
    }

}
