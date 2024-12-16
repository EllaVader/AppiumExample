using OpenQA.Selenium.Appium;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;


namespace AppiumExample.Config;

public class AppInitializer
{

    public static AppiumOptions DeviceOptions { get; set; }
    

// TODO NExt pass in string target property
    public static AppiumOptions InitializeSettings()
    {
        // /Users/janine/code/AppiumExample/AppiumExample/bin/Debug/net7.0/appsettings.json

        string target = "Android-Dev";
        IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json").Build();
        TestContext.Out.WriteLine($"Inside IntializeSettings - Target is: {target}");
        DeviceOptions = config.GetSection(target).Get<AppiumOptions>();
        // TODO: Verify not null
        TestContext.Out.WriteLine($"AppDetails is {DeviceOptions}");
        return DeviceOptions;
    }

}
