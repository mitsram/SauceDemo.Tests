using SauceDemo.Application.PageObjects;
using SauceDemo.Domain.Entities;

namespace SauceDemo.Application.UseCases;

public class AuthenticationUseCases
{
    private readonly AuthenticationPage _loginPage;

    public AuthenticationUseCases(AuthenticationPage loginPage)
    {
        _loginPage = loginPage;
    }

    public void GoToLoginPage()
    {
        _loginPage.NavigateToLoginPage();
    }

    public bool AttemptLogin(User user)
    {
        return _loginPage.Login(user.Username, user.Password);
    }

    public bool IsOnInventoryPage()
    {
        return _loginPage.IsOnInventoryPage();
    }

    public bool HasLoginError()
    {
        return _loginPage.HasLoginError();
    }
}

