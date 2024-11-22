using CleanTest.Framework.Factories;
using CleanTest.Framework.WebDriver.Interfaces;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
using SauceDemo.Tests.Config;

namespace SauceDemo.Tests.Specflow.Base;

[Parallelizable(ParallelScope.Self)]
public class BaseTestSpecflow
{
    protected static IWebDriverAdapter? driver { get; private set; }
    protected static TestConfiguration? TestConfig { get; private set; }
    
    protected readonly ScenarioContext _scenarioContext;
    protected readonly FeatureContext _featureContext;

    public BaseTestSpecflow(ScenarioContext scenarioContext, FeatureContext featureContext)
    {
        _scenarioContext = scenarioContext;
        _featureContext = featureContext;
    }

    public static void InitializeTestConfiguration()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        TestConfig = new TestConfiguration(configuration);
    }

    public static void InitializeWebDriver()
    {
        if (driver == null)
        {
            driver = WebDriverFactory.Create(TestConfig.WebDriverType, TestConfig.BrowserType);
        }
    }

    public static void CleanupWebDriver()
    {
        if (driver != null)
        {
            driver.Dispose();
            driver = null;
        }
    }
}
