using System;
using AppiumExample.Helpers;
using AppiumExample.Pages.Components;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppiumExample.Pages;

public class AppAlertDialogsPage : BasePage<AppAlertDialogsPage>
{
    
    /*
        TODO: see about front loading the fully qualified class name: "android:id" 
        so we can shorten by the id "parentPanel"
    */
        private By OkCancelDialogShortMessage => By.Id("io.appium.android.apis:id/two_buttons");

    public AppAlertDialogsPage(IWebDriver driver) : base(driver, "App/Alert Dialogs")
    { }

    public OkCancelShortDialog OpenOkCancelShortMessageDialog(){
        TestContext.Out.WriteLine("Opening OK/Cancel dialog with short message menu Item");

        Driver.FindElement(OkCancelDialogShortMessage).Click();
        OkCancelShortDialog okCancelDialog = new OkCancelShortDialog(Driver);
        //okCancelDialog.Load(); 
        return okCancelDialog;
    }


}
