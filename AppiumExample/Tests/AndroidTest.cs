using System;
using AppiumExample.Pages;
using AppiumExample.Pages.Components;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumExample;

/**
    TODO: 
    1. Create and Commit to git repo
    2. wait for element gone is taking too long - not honoring the wait
    3. Add IOS test
    4. loading of capabilities based on device
        - pass in parameter
        - read capabilities from json file
    5. Using seleinum grid to run in parallel - 

**/
public class Tests
{
    private AndroidDriver _driver;

    [OneTimeSetUp]
    public void SetUp()
    {
        // this will be abstracted out
        var serverUri = new Uri("http://127.0.0.1:4723");

        // this will be abstracted out for capabilites by device
        var options = new AppiumOptions()
        {
            DeviceName = "emulator-5554",
            PlatformName = "Android",
            AutomationName = "UiAutomator2",
            PlatformVersion = "14",
            App = "/Users/janine/code/AppiumExample/payloads/apks/ApiDemos-debug-appium.apk",
        };

        // TODO: learn about options / capibilities and what is needed
        // # https://medium.com/@wahyunitas/android-automation-testing-with-appium-adb8d9f6193f
        // https://github.com/appium/appium-uiautomator2-driver?tab=readme-ov-file#settings-api
        //options.AddAdditionalAppiumOption("appium:ensureWebviewsHavePages", true);
        //options.AddAdditionalAppiumOption("appium:nativeWebScreenshot", true);
        //options.AddAdditionalAppiumOption("appium:newCommandTimeout", 3600);
        //options.AddAdditionalAppiumOption("appium:connectHardwareKeyboard", true);

        // TODO: Android vs iOS strategy...
        _driver = new AndroidDriver(serverUri, options);

        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [Test]
    public void TestAppAlertDialog()
    {
        MainPage mainPage = new MainPage(_driver);

        AppPage appPage = mainPage.NavigateToAppPage();
        AppAlertDialogsPage appAlerts = appPage.NavigateToDialogsPage();
        OkCancelShortDialog dialog = appAlerts.OpenOkCancelShortMessageDialog();

        Assert.That(dialog.IsDialogDisplayed(), Is.True, "Ok/Cancel short dialog is not displayed");

        appAlerts = dialog.ClickOk();
        Assert.That(dialog.IsDialogDisplayed(), Is.False, "OK/Cancel shord dialog is not gone");
        
    }

    [OneTimeTearDown]
    public void TearDown(){
        _driver.Quit(); //TODO: Is this correct?
    }
}