using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppiumExample.Pages;

public class MainPage : BasePage<MainPage>
{

    private By AppMenuItem => By.XPath("//android.widget.TextView[@text='App']");

    public AppiumElement keyboard;


    public MainPage(IWebDriver driver) : base(driver, "API Demos"){
        // TODO: wait for loaded strategy?
    }

    public AppPage NavigateToAppPage(){
        TestContext.Out.WriteLine("Tapping App menu Item");
        Driver.FindElement(AppMenuItem).Click();
        AppPage appPage = new AppPage(Driver);

        return appPage;

    }

}
