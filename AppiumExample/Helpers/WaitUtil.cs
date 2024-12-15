using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AppiumExample.Helpers;

public static class WaitUtil
{

    public static AppiumElement WaitForElementVisible(IWebDriver driver, By elementLocator, int timeoutInSeconds = 3){
        
        WebDriverWait wait = InitializeWait(driver, timeoutInSeconds);
        TestContext.Out.WriteLine($"Waiting for element visible {elementLocator.Criteria}");
        IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
        return (AppiumElement)element; // TODO: see if AppiumELement buys us anything
    }

    public static void WaitForElementGone(IWebDriver driver, By elementLocator, int timeoutInSeconds = 3){
       
        WebDriverWait wait = InitializeWait(driver, timeoutInSeconds);
        TestContext.Out.WriteLine($"Waiting for element gone {elementLocator.Criteria}");
        wait.Until(ExpectedConditions.InvisibilityOfElementLocated(elementLocator));
    }

    public static bool IsElementVisible(IWebDriver driver, By elementLocator, int timeoutInSeconds = 3){
        WebDriverWait wait = InitializeWait(driver, timeoutInSeconds);
        
        var elements =  driver.FindElements(elementLocator);
        return elements.Count > 0;
    }

    private static WebDriverWait InitializeWait(IWebDriver driver, int timeoutInSeconds = 3){
       return new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
    }

}
