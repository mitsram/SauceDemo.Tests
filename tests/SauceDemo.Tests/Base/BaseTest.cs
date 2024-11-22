using CleanTest.Framework.Factories;
using CleanTest.Framework.WebDriver.Interfaces;
using SauceDemo.Tests.Config;
using Microsoft.Extensions.Configuration;

namespace SauceDemo.Tests.Base;

public class BaseTest
{
    protected IWebDriverAdapter driver;    
    protected TestConfiguration TestConfig { get; private set; }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(TestContext.CurrentContext.TestDirectory)
            .AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        TestConfig = new TestConfiguration(configuration);
    }

    [SetUp]
    public void SetUp()
    {
        driver = WebDriverFactory.Create(TestConfig.WebDriverType, TestConfig.BrowserType, TestConfig.Headless);
    }

    [TearDown]
    public void TearDown()
    {
        Thread.Sleep(1000);
        if (driver != null)
        {
            driver.Dispose();
        }
    }
}
