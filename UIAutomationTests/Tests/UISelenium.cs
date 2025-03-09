

namespace UIAPIAutomationTests.Tests
{
    [TestClass]
    public class UISelenium 
    {
        Initialise s1 = Initialise.GetInstance();

        [TestInitialize]
        public void testSetup()
        {
            string dtime = DateTime.Now.ToString("MdyyyyHHmmss",
                                     CultureInfo.InvariantCulture);
            s1.setup(Input.TestData.URLString, BrowserType.Chrome);
            s1.getReportClass();
            s1.pageClasses();
            s1.reports.StartReport(s1.getProjectPath() + TestContext.TestName + "_" + dtime +".html");
            s1.reports.StartExtentTest(TestContext.TestName);
           
        }

        [TestMethod]
        public void verifyUserMessage()
        {
            try
            {

                s1.hpage.enterUserMessage(Input.TestData.searchText, "Search Text Entered");
                s1.hpage.clickMethod("Button is Clicked");

                Assert.IsTrue(s1.hpage.getMessage("Search Text Results Displayed").Equals(Input.TestData.searchText),
                             "The expected message was not displayed.");
                string dtime = DateTime.Now.ToString("MdyyyyHHmmss",
                                    CultureInfo.InvariantCulture);
                s1.reports.includeAttachmentReport(s1.driver, s1.getProjectPath()+ "\\Screenshots\\" + "Web" + "_" + dtime + ".png", "Search Text Results Displayed");

                s1.reports.LoggingTestStatusExtentReport(TestStatus.Pass.ToString(), "VerifyUserMessage Test Passed");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                string dtime = DateTime.Now.ToString("MdyyyyHHmmss",
                                    CultureInfo.InvariantCulture);
                s1.reports.includeAttachmentReport(s1.driver, s1.getProjectPath() + "\\Screenshots\\" + "Web" + "_" + dtime + ".png", "Search Text Results Not Displayed");
                s1.reports.LoggingTestStatusExtentReport(TestStatus.Fail.ToString(), e.Message);
            }

        }

        [TestCleanup]
        public void testTearDown()
        {
            s1.tearDown();
            s1.reports.extentCleanUp();
        }


        public TestContext TestContext { get; set; }
    }
}