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

> If you're running this template for the first time, it might give you and error and suggest to run the pwsh bin/Debug/net<version>/playwright.ps1 install command. If you're using Mac, you can install powershell using brew: brew install powershell