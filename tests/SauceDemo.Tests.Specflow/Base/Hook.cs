using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SauceDemo.Tests.Specflow.Base;

[Binding]
public class Hook : BaseTestSpecflow
{
    public Hook(ScenarioContext scenarioContext, FeatureContext featureContext) 
        : base(scenarioContext, featureContext)
    {
    }

    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        InitializeTestConfiguration();
        Console.WriteLine("Test run started");
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        CleanupWebDriver();
        Console.WriteLine("Test run completed");
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        InitializeWebDriver();
        Console.WriteLine($"Starting scenario: {_scenarioContext.ScenarioInfo.Title}");
    }

    [AfterScenario]
    public void AfterScenario()
    {
        // if (_scenarioContext.TestError != null)
        // {
        //     var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        //     var fileName = $"error_{DateTime.Now:yyyyMMdd_HHmmss}.png";
        //     screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
        //     Console.WriteLine($"Screenshot saved as {fileName}");
        // }

        Thread.Sleep(1000); // Similar to your original TearDown
        Console.WriteLine($"Scenario completed: {_scenarioContext.ScenarioInfo.Title}");
        CleanupWebDriver();
    }
}
