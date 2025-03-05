
namespace UtilityProject
{
    public class ReportBDD
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        public static void ExtentReportInit(string reportPath)
        {
            var htmlReporter = new ExtentSparkReporter(reportPath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Standard;

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "DemoApp");
            _extentReports.AddSystemInfo("Browser", "Chrome");
            _extentReports.AddSystemInfo("OS", "Windows");
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }

        public string addScreenshot(IWebDriver driver, ScenarioContext scenarioContext, string reportPath)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            string dtime = DateTime.Now.ToString("MdyyyyHHmmss",
                                    CultureInfo.InvariantCulture);
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(reportPath, scenarioContext.ScenarioInfo.Title.Trim() + "_" + dtime + ".png");
            screenshot.SaveAsFile(screenshotLocation);
            return screenshotLocation;
        }


    }
}
