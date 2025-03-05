
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Service;

namespace AppiumExample.Libraries
{
    public class AndroidDriverFactory : IWebDriverFactory
    {
        public AndroidDriver CreateAndroidDriver(AppiumLocalService _appiumLocalService, AppiumOptions options)
        {
            return new AndroidDriver(_appiumLocalService, options, TimeSpan.FromSeconds(180));
        }


        public IOSDriver CreateiOSDriver(AppiumLocalService _appiumLocalService, AppiumOptions options)
        {
            return null;
        }
    }
 
}
