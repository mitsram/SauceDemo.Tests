using SauceDemo.Application.PageObjects;

namespace SauceDemo.Application.UseCases;

public class ShopUseCases
{
    private readonly ShopPage _shopPage;

    public ShopUseCases(ShopPage shopPage)
    {
        _shopPage = shopPage;
    }

    public void AddProductToCart(string productName)
    {
        _shopPage.AddProductToCart(productName);
    }

    public bool IsProductInCart(string productName)
    {
        return _shopPage.IsProductInCart(productName);
    }

    public int GetCartItemCount()
    {
        return _shopPage.GetCartItemCount();
    }

    public void RemoveProductFromCart(string productName)
    {
        _shopPage.RemoveProductFromCart(productName);
    }

    public void SortProducts(string sortOption)
    {
        _shopPage.SortProducts(sortOption);
    }

    public bool AreProductsSortedCorrectly(string sortOption)
    {
        return _shopPage.AreProductsSortedCorrectly(sortOption);
    }

    public bool IsOnProductPage()
    {
        return _shopPage.IsOnProductPage();
    }

    public bool SearchForProduct(string productName)
    {
        return _shopPage.SearchForProduct(productName);
    }

    public void GoToCart()
    {
        _shopPage.NavigateToCart();
    }
}
