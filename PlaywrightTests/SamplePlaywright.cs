
namespace PlaywrightTests
{
    [TestFixture]
    public class SamplePlaywright
    {
        
        [Test]
        public async Task FirstPlaywrightMethod()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = false });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://playwright.dev/dotnet");
            await page.ScreenshotAsync(new() { Path = "screenshot.png" });
        }
    }
}