using SauceDemo.Application.PageObjects;
using SauceDemo.Tests.Base;
using SauceDemo.Application.UseCases;
using SauceDemo.Domain.Entities;

namespace SauceDemo.Tests.Specs;

public class ShopTests : BaseTest
{
    private ShopUseCases shop;
    private AuthenticationUseCases authentication;

    [SetUp]
    public void SetUp()
    {
        shop = new ShopUseCases(new ShopPage(driver!));
        authentication = new AuthenticationUseCases(new AuthenticationPage(driver!));

        // Login before each test
        authentication.GoToLoginPage();
        authentication.AttemptLogin(new User { Username = "standard_user", Password = "secret_sauce" });
    }    

    [Test]
    public void Should_AddProductToCart_WhenProductIsAvailable()
    {
        // Arrange
        var product = new Product { Name = "Sauce Labs Backpack" };

        // Act 
        shop.AddProductToCart(product.Name);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(shop.IsProductInCart(product.Name), Is.True);
            Assert.That(shop.GetCartItemCount(), Is.EqualTo(1));
        });
    }

    [Test]    
    public void Should_RemoveProductFromCart_WhenProductIsInCart()
    {
        // Arrange
        var product = new Product { Name = "Sauce Labs Bike Light" };
        shop.AddProductToCart(product.Name);

        // Act
        shop.RemoveProductFromCart(product.Name);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(shop.IsProductInCart(product.Name), Is.False);
            Assert.That(shop.GetCartItemCount(), Is.EqualTo(0));
        });
    }

    [Test]    
    public void Should_SortProducts_WhenSortOptionIsSelected()
    {
        // Arrange
        string sortOption = "Price (high to low)";

        // Act
        shop.SortProducts(sortOption);

        // Assert
        Assert.That(shop.AreProductsSortedCorrectly(sortOption), Is.True);
    }
}

