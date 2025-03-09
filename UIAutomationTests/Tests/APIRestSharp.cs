
namespace UIAPIAutomationTests.Tests
{
    [TestClass]
    public class APIRestSharp
    {
        Initialise initialise = Initialise.GetInstance();

        [TestInitialize]
        public void setup()
        {
          string dtime = DateTime.Now.ToString("MdyyyyHHmmss",
                               CultureInfo.InvariantCulture);
          initialise.getReportClass();
          initialise.getAPIMethodClass();
          initialise.reports.StartReport(initialise.getProjectPath() + TestContext.TestName + "_" + dtime + ".html");
          initialise.reports.StartExtentTest(TestContext.TestName);
        }


        [TestMethod]
        public void testAPIMethod()
        {
            try
            {


                initialise.apiMethods.initialiseAPIClient(Input.TestData.BaseURL, Input.TestData.getProductById);

                initialise.apiMethods.response = initialise.apiMethods.getRequest();


                Console.WriteLine("Status Code: " + initialise.apiMethods.response.StatusCode.ToString());
                Console.WriteLine("Content Type: " + initialise.apiMethods.response.ContentType.ToString());

                if (!initialise.apiMethods.response.StatusCode.ToString().Equals("OK"))
                {
                    throw new Exception("API Response Status is invalid " + initialise.apiMethods.response.StatusCode.ToString());
                }

                // deserialize json string response to JsonNode object
                var data = JsonSerializer.Deserialize<JsonNode>(initialise.apiMethods.response.Content!)!;

                initialise.reports.LoggingTestStatusExtentReport(TestStatus.Pass.ToString(), TestContext.TestName + " Method Return Values " + data["id"] + " " + data["name"]);
            }
            catch(Exception exp)
            {
                initialise.reports.LoggingTestStatusExtentReport(TestStatus.Fail.ToString(), TestContext.TestName + " Test Method Failed " + exp.Message);
            }
        }

        [TestCleanup]
        public void tearDown()
        {
            initialise.apiMethods.apitearDown();
            initialise.reports.extentCleanUp();
        }

        public TestContext TestContext { get; set; }

    }
}
