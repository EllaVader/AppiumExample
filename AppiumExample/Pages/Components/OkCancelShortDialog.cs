using System;
using AppiumExample.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AppiumExample.Pages.Components;

public class OkCancelShortDialog : BasePage<OkCancelShortDialog>
{
    
    private By OkCancelDialog => By.Id("android:id/parentPanel");
    private By OkButton => By.XPath("//android.widget.Button[@text='OK']");
    private By CloseButton => By.XPath("//android.widget.Button[@text='Cancel']");


    public OkCancelShortDialog(IWebDriver driver) : base(driver, "NONE")
    { }

    public AppAlertDialogsPage ClickOk(){
         TestContext.Out.WriteLine("Closing the dialog by clicking OK");
         Driver.FindElement(OkButton).Click();
         WaitUtil.WaitForElementGone(Driver, OkCancelDialog);
        
          var dialogPage = new AppAlertDialogsPage(Driver);
          return dialogPage;
    }


    public bool IsDialogDisplayed(){
        bool found = WaitUtil.IsElementVisible(Driver, OkCancelDialog, 1);
        return found;
    }

    protected override bool EvaluateLoadedStatus()
    {
        WaitUtil.WaitForElementVisible(Driver, OkCancelDialog);
        return true;
    }

}
