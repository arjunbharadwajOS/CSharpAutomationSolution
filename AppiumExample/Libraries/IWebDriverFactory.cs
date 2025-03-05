
using OpenQA.Selenium.Appium.iOS;

namespace AppiumExample.Libraries
{
    public interface IWebDriverFactory
    {
        AndroidDriver CreateAndroidDriver(AppiumLocalService _appiumLocalService, AppiumOptions options);

        IOSDriver CreateiOSDriver(AppiumLocalService _appiumLocalService, AppiumOptions options);

    }
}
