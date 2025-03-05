using AppiumExample.Libraries;
using AppiumExample.Pages.Android;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System.Reflection;

namespace AppiumExample
{
    public enum DeviceType
    {
        android,
        ios
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
        public IWebDriver driver;
        public static AppiumLocalService _appiumLocalService;
        public static AppiumOptions options;
        public SettingsPage settingsPage = null;
        public Reports reports = null;

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

 
        public void setup(DeviceType deviceType)
        {
            startAppiumService();
            options = appiumOptions(deviceType);

            // Initialize the driver
            driver = WebDriverFactory.GetWebDriver(deviceType,_appiumLocalService, options);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void startAppiumService()
        {
            _appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            _appiumLocalService.Start();
        }

        public AppiumOptions appiumOptions(DeviceType deviceType)
        {
            options = new AppiumOptions()
            {
                AutomationName = TestData.Data.AutomationName,
                PlatformName = TestData.Data.PlatformName,
                DeviceName = TestData.Data.DeviceName
            };

            switch (deviceType)
            {
                case DeviceType.android:
                     return androidOptions(options);
                case DeviceType.ios:
                    return iOSOptions(options);
                default:
                    throw new ArgumentException("Unsupported device type.");
            }


        }

        public AppiumOptions androidOptions(AppiumOptions appOptions)
        {
            appOptions.AddAdditionalAppiumOption("appPackage", TestData.Data.appPackage);
            appOptions.AddAdditionalAppiumOption("appActivity", TestData.Data.appActivity);
            appOptions.AddAdditionalAppiumOption("appWaitForLaunch", false);

            return appOptions;
        }

        public AppiumOptions iOSOptions(AppiumOptions appOptions)
        {
            appOptions.AddAdditionalAppiumOption("bundleId", TestData.Data.appPackage);
         
            return appOptions;
        }

        public void pageClasses()
        {
            settingsPage = new SettingsPage(driver, reports);
        }

        public void getReportClass()
        {
            reports = new Reports();
        }
       
        public void tearDown()
        {
            _appiumLocalService.Dispose();
            driver.Quit();
            driver.Dispose();
        }

        
    }

}
