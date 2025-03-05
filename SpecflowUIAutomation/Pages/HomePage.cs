namespace SpecflowUIAutomation.Pages
{
    public class HomePage
    {

        public IWebDriver _driver = null;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        By userMessage = By.Id("user-message");
        By showInput = By.Id("showInput");
        By message = By.Id("message");


        public void enterUserMessage(string messageText)
        {
            try
            {
                _driver.FindElement(userMessage).SendKeys(messageText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void clickMethod()
        {
            try
            {
                _driver.FindElement(showInput).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string getMessage()
        {
            string returnText = "";

            try
            {
                returnText = _driver.FindElement(message).Text;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return returnText;
        }

        public string getPageTitle()
        {
            string pageTitle = "";

            try
            {
                pageTitle = _driver.Title.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return pageTitle;
        }

    }
}
