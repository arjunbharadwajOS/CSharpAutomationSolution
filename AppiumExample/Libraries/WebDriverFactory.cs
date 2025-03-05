
using AppiumExample;

namespace AppiumExample.Libraries
{
    public class WebDriverFactory
    {
        public static IWebDriver GetWebDriver(DeviceType deviceType, AppiumLocalService _appiumLocalService, AppiumOptions options)
        {
            switch (deviceType)
            {                                                                               
                case DeviceType.android:
                    return new AndroidDriverFactory().CreateAndroidDriver(_appiumLocalService, options);
                case DeviceType.ios:
                    return new iOSDriverFactory().CreateiOSDriver(_appiumLocalService, options);
                default:
                    throw new ArgumentException("Unsupported device type.");
            }
        }
    }
}
