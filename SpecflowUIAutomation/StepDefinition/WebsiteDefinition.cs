namespace SpecflowUIAutomation.StepDefinition
{
        [Binding]
        public class WebsiteDefinition
    {
            Hooks s1 = Hooks.Instance;


            [Given("I launch the website")]
            public void GivenILaunchTheWebsite()
            {
                s1.pageClasses();
                string pageTitle = s1.hpage.getPageTitle();

            }

            [When("I enter text and click method")]
            public void WhenIEnterTextAndClickMethod()
            {
                try
                {
                    s1.hpage.enterUserMessage("LambdaTest rules");
                    s1.hpage.clickMethod();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            [Then("I view the results")]
            public void ThenIViewTheResults()
            {
                Assert.IsTrue(s1.hpage.getMessage().Equals("LambdaTest rules"),
                                 "The expected message was not displayed.");
            }

        }

}
