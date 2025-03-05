

using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Reqnroll.BoDi;
using SpecflowUIAutomation.Pages;
using System.Globalization;
using System.Reflection;
using UtilityProject;
using static SpecflowUIAutomation.Libraries.WebDriverFactory;
using SpecflowUIAutomation.Libraries;
using Feature = AventStack.ExtentReports.Gherkin.Model.Feature;
using Scenario = AventStack.ExtentReports.Gherkin.Model.Scenario;

namespace SpecflowUIAutomation.HooksClass
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

    [Binding]
    public class Hooks : ReportBDD
    {
        private readonly IObjectContainer _container;

        static Hooks _instance;
        public static IWebDriver driver = null;
        public HomePage hpage = null;

        public static Hooks Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Hooks();

                return _instance;
            }
        }

        public Hooks()
        {

        }

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run...");
            
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after test run...");
            ExtentReportTearDown();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running before feature...");
            string dtime = DateTime.Now.ToString("MdyyyyHHmmss",
                                     CultureInfo.InvariantCulture);
            ExtentReportInit(getProjectPath() + featureContext.FeatureInfo.Title.Trim()  + "_" + dtime + ".html");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Running after feature...");
        }

        [BeforeScenario("@Testers")]
        public void BeforeScenarioWithTag()
        {
            Console.WriteLine("Running inside tagged hooks in specflow");
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running before scenario...");

            setup(TestData.Data.URLString.ToString(), BrowserType.Chrome);
            
            _container.RegisterInstanceAs<IWebDriver>(driver);

            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);

        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Running after scenario...");

            tearDown();
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running after step....");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            //When scenario passed
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Pass(MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext, getScreenshotProjectPath())).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName);
                }
            }

            //When scenario fails
            if (scenarioContext.TestError != null)
            {

                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext, getScreenshotProjectPath())).Build());
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext, getScreenshotProjectPath())).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext, getScreenshotProjectPath())).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext, getScreenshotProjectPath())).Build());
                }
            }
        }

        public static string getProjectPath()
        {
            string path = Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;

            string reportPath = projectPath + "TestResults\\";
            return reportPath;
        }

        public static string getScreenshotProjectPath()
        {
            string path = Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;

            string reportPath = projectPath + "TestResults\\Screenshots\\";
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
            hpage = new HomePage(driver);
        }

        public void tearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

    }
}