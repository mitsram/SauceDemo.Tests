# SauceDemo.Tests

## Overview

This project contains automated tests for the SauceDemo application, utilizing the CleanTest.Framework library. The tests are structured following the principles of Clean Architecture, ensuring flexibility and maintainability. One of the key benefits of this architecture is the ability to switch between different test tools, such as Selenium or Playwright, without requiring changes to the test cases themselves. This flexibility allows for easy adaptation to new technologies while maintaining a consistent testing strategy.

## Getting Started
1. Clone the repository:
   ```bash
   git clone git@github.com:mitsram/SauceDemo.Tests.git
   cd SauceDemo.Tests
   ```

2. Restore the dependencies:
   ```bash
   dotnet restore
   ```

3. Run the tests:
   ```bash
   dotnet test
   ```

> If you're running this project for the first time, it might give you and error and suggest to run the pwsh bin/Debug/net<version>/playwright.ps1 install command. If you're using Mac, you can install powershell using brew: brew install powershell

## Switching Between Selenium and Playwright

To switch between Selenium and Playwright, follow these steps:

#### Update the Test Configuration
Modify the `appsettings.json` file to specify the desired WebDriver type. For example, to use Selenium, set:
   ```json
   {
       "WebDriverType": "Selenium",
       ...
   }
   ```
   To switch back to Playwright, set:
   ```json
   {
       "WebDriverType": "Playwright",
       ...
   }
   ```

## Other Test Configuration Options

### Browser
Modify the appsettings.json for the desired browser:
   ```json
   {
       "BrowserType": "Chrome",
       ...
   }
   ```
### Headless
Accepts true or false:
   ```json
   {
      ...
      "TestSettings": {
         "BaseUrl": "https://www.saucedemo.com",
         "Headless": false,
         "Timeout": 30
      }
   }
   ```