

using System.Globalization;

namespace AppiumExample
{
    [TestFixture]
    public class AppiumTest
    {
        

        Initialise s1 = Initialise.Instance;

        [SetUp]
        public void setUp()
        {
            string dtime = DateTime.Now.ToString("MdyyyyHHmmss",
                                     CultureInfo.InvariantCulture);
            s1.setup(DeviceType.android);
            s1.getReportClass();
            s1.pageClasses();
            s1.reports.StartReport(s1.getProjectPath() + TestContext.CurrentContext.Test.Name + "_" + dtime + ".html");
            s1.reports.StartExtentTest(TestContext.CurrentContext.Test.Name);

        }



        [Test]
        public void appiumMethod()
        {
            string individualMethodstatus = "";

            try
            {
                individualMethodstatus = s1.settingsPage.startAcivity(TestData.Data.appPackage,TestData.Data.appActivity, "Activity Launched");

                individualMethodstatus = s1.settingsPage.clickMethod("Button is Clicked");

                if (individualMethodstatus.StartsWith("Error"))
                {
                    throw new Exception(individualMethodstatus);
                }

                string dtime = DateTime.Now.ToString("MdyyyyHHmmss",
                                    CultureInfo.InvariantCulture);
                s1.reports.includeAttachmentReport(s1.driver, s1.getProjectPath() + "\\Screenshots\\" + "App" + "_" + dtime + ".png", "Battery Page Displayed");

                s1.reports.LoggingTestStatusExtentReport(TestStatus.Pass.ToString(), "Button Click Passed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                string dtime = DateTime.Now.ToString("MdyyyyHHmmss",
                                    CultureInfo.InvariantCulture);
                s1.reports.includeAttachmentReport(s1.driver, s1.getProjectPath() + "\\Screenshots\\" + "App" + "_" + dtime + ".png", "Battery Page Not Displayed");
                s1.reports.LoggingTestStatusExtentReport(TestStatus.Fail.ToString(), e.Message);
            }

        }

        [TearDown]
        public void tearDown()
        {
            s1.tearDown();
            s1.reports.extentCleanUp();
        }

        public TestContext TestContext { get; set; }

    }
}