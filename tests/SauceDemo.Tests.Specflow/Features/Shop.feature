Feature: Shopping Cart Management
As a customer
I want to manage products in my shopping cart
So that I can purchase items I want

Background:
    Given I am logged in as "standard_user" with password "secret_sauce"

Scenario: Add product to cart
    Given I am on the products page
    When I add "Sauce Labs Backpack" to the cart
    Then the "Sauce Labs Backpack" should be in the cart
    And the cart should contain 1 item

Scenario: Remove product from cart
    Given I am on the products page
    And I have added "Sauce Labs Bike Light" to the cart
    When I remove "Sauce Labs Bike Light" from the cart
    Then the "Sauce Labs Bike Light" should not be in the cart
    And the cart should contain 0 items

Scenario: Sort products by price high to low
    Given I am on the products page
    When I sort products by "Price (high to low)"
    Then the products should be correctly sorted by "Price (high to low)"