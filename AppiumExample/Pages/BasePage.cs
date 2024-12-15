using System;
using AppiumExample.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AppiumExample.Pages;

/**

Now, by having our Page Objects extend the LoadableComponent base class, we need to implement two new methods, load() and isLoaded() (note that in C#, these are called ExecuteLoad() and EvaluateLoadedStatus() for some reason). These methods provide the added value of using the LoadableComponent pattern. The load() method contains the code that is executed to navigate to the page, while the isLoaded() method is used to evaluate whether we are on the correct page and whether page loading has finished successfully. Using LoadableComponent, our LoginPage class now looks like this:
**/


public abstract class BasePage<T> : LoadableComponent<BasePage<T>>
{
    // sets global implicit timeout 
    private readonly int _defaultTimeout = 3;
    protected IWebDriver Driver;

    protected string HeaderLabel;
    protected By Header => By.XPath($"//android.widget.TextView[@text='{HeaderLabel}']");

    protected BasePage(IWebDriver driver, string headerLabel){
        Driver = driver;
        HeaderLabel = headerLabel;
        // calls EvaluateLoadedStatus
        Load();

         driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_defaultTimeout);
    }

    protected override void ExecuteLoad()
    {
        throw new NotImplementedException();
    }

    protected override bool EvaluateLoadedStatus()
    {
        WaitUtil.WaitForElementVisible(Driver, Header);
        return true;
    }



}
