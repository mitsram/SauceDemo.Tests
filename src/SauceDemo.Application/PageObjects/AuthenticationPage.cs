using CleanTest.Framework.WebDriver.Interfaces;

namespace SauceDemo.Application.PageObjects;

public class AuthenticationPage : IDisposable
{
    private readonly IWebDriverAdapter driver;
    private bool _disposed = false;

    public AuthenticationPage(IWebDriverAdapter driverAdapter)
    {
        driver = driverAdapter;
    }

    public void NavigateToLoginPage()
    {
        driver.NavigateToUrl("https://www.saucedemo.com/");
        
        // Optionally, we can add a check to ensure the page has loaded
        var usernameField = driver.FindElementById("user-name");
        if (usernameField == null)
        {
            throw new Exception("Login page did not load properly");
        }
    }

    public bool Login(string username, string password)
    {
        var usernameField = driver.FindElementById("user-name");
        var passwordField = driver.FindElementById("password");
        var loginButton = driver.FindElementById("login-button");

        usernameField.SendKeys(username);
        passwordField.SendKeys(password);
        loginButton.Click();

        return IsOnInventoryPage();
    }

    public bool IsOnInventoryPage()
    {
        return driver.GetCurrentUrl().EndsWith("/inventory.html");
    }

    public bool HasLoginError()
    {
        var errorElement = driver.FindElementByClassName("error-message-container");
        return !string.IsNullOrEmpty(errorElement.Text);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Implement disposal logic using _driverStrategy
            }
            _disposed = true;
        }
    }

    ~AuthenticationPage()
    {
        Dispose(false);
    }
}

