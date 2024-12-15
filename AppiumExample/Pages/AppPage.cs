using System;
using AppiumExample.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AppiumExample.Pages;

public class AppPage : BasePage<AppPage>
{
    public AppPage(IWebDriver driver) : base(driver, "API Demos")
    {
    }
 

    private By AlertDialogsMenuItem => By.XPath("//android.widget.TextView[@text='Alert Dialogs']");

    public AppAlertDialogsPage NavigateToDialogsPage(){
        TestContext.Out.WriteLine("Tapping Alert Dialogs menu Item");
        Driver.FindElement(AlertDialogsMenuItem).Click();
        AppAlertDialogsPage alertPage = new AppAlertDialogsPage(Driver);
        return alertPage;
    }

    protected override bool EvaluateLoadedStatus()
    {
        WaitUtil.WaitForElementVisible(Driver, AlertDialogsMenuItem);
        return true;
    }

}
