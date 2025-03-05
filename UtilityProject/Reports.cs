

using OpenQA.Selenium;
using System.Globalization;
using System.Xml.Linq;

namespace UtilityProject
{
    public class Reports
    {
        public static ExtentReports extent;
        public static ExtentTest testlog;
        public static ExtentSparkReporter htmlReporter;

        public void StartReport(string reportPath)
        {         
            htmlReporter = new ExtentSparkReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Tester", Environment.UserName);
            extent.AddSystemInfo("MachineName", Environment.MachineName);

        }

        public void StartExtentTest(string testsToStart)
        {
            testlog = extent.CreateTest(testsToStart);
        }


        public void LoggingTestStatusExtentReport(string status, string message)
        {
            if (status.Equals("Pass"))
            {
                testlog.Log(Status.Pass, message);
            }
            else if (status.Equals("Fail"))
            {
                testlog.Log(Status.Fail, message);
            }
            else
            {
                testlog.Log(Status.Skip, message);
            }

        }


        public void includeAttachmentReport(IWebDriver webDriver, string attachmentFile, string statusMessage)
        {
         
            Screenshot file = ((ITakesScreenshot)webDriver).GetScreenshot();

            //To save screenshot
            file.SaveAsFile(attachmentFile);

            //To log screenshot
            testlog.Info(statusMessage, MediaEntityBuilder.CreateScreenCaptureFromPath(attachmentFile).Build());
        }

        public void extentCleanUp()
        {
            extent.Flush();
        }
    }
}