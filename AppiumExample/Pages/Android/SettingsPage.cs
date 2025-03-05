namespace AppiumExample.Pages.Android
{
    public class SettingsPage
    {

        public AndroidDriver _driver = null;

        public Reports _reports = null;

        public SettingsPage(IWebDriver driver, Reports reports)
        {
            _driver = (AndroidDriver)driver;
            _reports = reports;
        }

        By battery = By.XPath("//*[@text='Battery']");
     
        public string startAcivity(string packagename, string acivityname, string statusMsg)
        {
            string methodStatus = "";

            try
            {
                _driver.StartActivity(packagename, acivityname);
                _reports.LoggingTestStatusExtentReport(TestStatus.Pass.ToString(), statusMsg);
                methodStatus = statusMsg;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _reports.LoggingTestStatusExtentReport(TestStatus.Fail.ToString(), e.Message);
                methodStatus = "Error " + e.Message;
            }

            return methodStatus;
        }

        public string clickMethod(string statusMsg)
        {
            string methodStatus = "";

            try
            {
                _driver.FindElement(battery).Click();
                _reports.LoggingTestStatusExtentReport(TestStatus.Pass.ToString(), statusMsg);
                methodStatus = statusMsg;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _reports.LoggingTestStatusExtentReport(TestStatus.Fail.ToString(), e.Message);
                methodStatus = "Error " + e.Message;
            }

            return methodStatus;
        }
       
    }
}
