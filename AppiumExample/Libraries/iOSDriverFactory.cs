
using OpenQA.Selenium.Appium.iOS;

namespace AppiumExample.Libraries
{
    public class iOSDriverFactory : IWebDriverFactory
    {
        public AndroidDriver CreateAndroidDriver(AppiumLocalService _appiumLocalService, AppiumOptions options)
        {
            return null;
        }


        public IOSDriver CreateiOSDriver(AppiumLocalService _appiumLocalService, AppiumOptions options)
        {
            return new IOSDriver(_appiumLocalService, options, TimeSpan.FromSeconds(180));
        }

    }
}
