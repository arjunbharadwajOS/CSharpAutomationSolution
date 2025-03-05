

namespace UIAPIAutomationTests.Pages
{
    public class HomePage
    {

        public IWebDriver _driver = null;

        public Reports _reports = null;

        public HomePage(IWebDriver driver, Reports reports)
        {
            _driver = driver;
            _reports = reports;
        }

        By userMessage = By.Id("user-message");
        By showInput = By.Id("showInput");
        By message = By.Id("message");


        public void enterUserMessage(string messageText, string statusMsg)
        {
            try
            {
                _driver.FindElement(userMessage).SendKeys(messageText);
                _reports.LoggingTestStatusExtentReport(TestStatus.Pass.ToString(), statusMsg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _reports.LoggingTestStatusExtentReport(TestStatus.Fail.ToString(), e.Message);
            }
        }

        public void clickMethod(string statusMsg)
        {
            try
            {
                _driver.FindElement(showInput).Click();
                _reports.LoggingTestStatusExtentReport(TestStatus.Pass.ToString(), statusMsg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _reports.LoggingTestStatusExtentReport(TestStatus.Fail.ToString(), e.Message);
            }
        }

        public string getMessage(string statusMsg)
        {
            string returnText = "";

            try
            {
                returnText = _driver.FindElement(message).Text;
                _reports.LoggingTestStatusExtentReport(TestStatus.Pass.ToString(), statusMsg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _reports.LoggingTestStatusExtentReport(TestStatus.Fail.ToString(), e.Message);
            }
            return returnText;
        }

        public string getPageTitle(string statusMsg)
        {
           string pageTitle = "";

            try
            {
                pageTitle = _driver.Title.ToString();
                _reports.LoggingTestStatusExtentReport(TestStatus.Pass.ToString(), statusMsg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _reports.LoggingTestStatusExtentReport(TestStatus.Fail.ToString(), e.Message);
            }
            return pageTitle;
        }

    }
}
