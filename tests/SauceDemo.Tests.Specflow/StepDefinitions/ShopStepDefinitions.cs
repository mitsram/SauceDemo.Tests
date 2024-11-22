using TechTalk.SpecFlow;
using SauceDemo.Tests.Specflow.Base;
using SauceDemo.Application.UseCases;
using SauceDemo.Domain.Entities;
using SauceDemo.Application.PageObjects;

namespace SauceDemo.Tests.Specflow.StepDefinitions;

[Binding]
public class ShopStepDefinitions : BaseTestSpecflow
{
    private ShopUseCases _shop;
    private AuthenticationUseCases _authentication;

    public ShopStepDefinitions(ScenarioContext scenarioContext, FeatureContext featureContext) 
        : base(scenarioContext, featureContext)
    {
        _shop = new ShopUseCases(new ShopPage(driver));
        _authentication = new AuthenticationUseCases(new AuthenticationPage(driver));
    }

    [Given(@"I am logged in as ""(.*)"" with password ""(.*)""")]
    public void GivenIAmLoggedInAs(string username, string password)
    {
        _authentication.GoToLoginPage();
        _authentication.AttemptLogin(new User { Username = username, Password = password });
    }

    [Given(@"I am on the products page")]
    public void GivenIAmOnTheProductsPage()
    {
        Assert.That(_shop.IsOnProductPage(), Is.True);
    }

    [Given(@"I have added ""(.*)"" to the cart")]
    public void GivenIHaveAddedToTheCart(string productName)
    {
        _shop.AddProductToCart(productName);
    }

    [When(@"I add ""(.*)"" to the cart")]
    public void WhenIAddToTheCart(string productName)
    {
        _shop.AddProductToCart(productName);
    }

    [When(@"I remove ""(.*)"" from the cart")]
    public void WhenIRemoveFromTheCart(string productName)
    {
        _shop.RemoveProductFromCart(productName);
    }

    [When(@"I sort products by ""(.*)""")]
    public void WhenISortProductsBy(string sortOption)
    {
        _shop.SortProducts(sortOption);
    }

    [Then(@"the ""(.*)"" should be in the cart")]
    public void ThenTheProductShouldBeInTheCart(string productName)
    {
        Assert.That(_shop.IsProductInCart(productName), Is.True);
    }

    [Then(@"the ""(.*)"" should not be in the cart")]
    public void ThenTheProductShouldNotBeInTheCart(string productName)
    {
        Assert.That(_shop.IsProductInCart(productName), Is.False);
    }

    [Then(@"the cart should contain (.*) items?")]
    public void ThenTheCartShouldContainItems(int expectedCount)
    {
        Assert.That(_shop.GetCartItemCount(), Is.EqualTo(expectedCount));
    }

    [Then(@"the products should be correctly sorted by ""(.*)""")]
    public void ThenTheProductsShouldBeCorrectlySortedBy(string sortOption)
    {
        Assert.That(_shop.AreProductsSortedCorrectly(sortOption), Is.True);
    }
} 