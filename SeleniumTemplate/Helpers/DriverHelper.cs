using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumTemplate.Enums;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumTemplate.Helpers;

public static class DriverHelper
{
    public static IWebDriver GetWebDriver()
    {
        switch (SetupHelper.Browser)
        {
            case Browser.Chrome:
                return SetupChromeDriver();
            case Browser.Firefox:
                return SetupFirefoxDriver();
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static ChromeDriver SetupChromeDriver()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        ChromeOptions opt = new();
        opt.AddAdditionalOption(CapabilityType.AcceptInsecureCertificates, true);
        if (SetupHelper.RunInHeadlessMode)
        {
            opt.AddArguments("--window-size=1920, 1080");
            opt.AddArguments("--start-maximized");
            opt.AddArguments("--headless");
        }
        var driver = new ChromeDriver(opt);
        if (!SetupHelper.RunInHeadlessMode)
        {
            driver.Manage().Window.Maximize();
        }

        return driver;
    }

    private static FirefoxDriver SetupFirefoxDriver()
    {
        new DriverManager().SetUpDriver(new FirefoxConfig());
        FirefoxOptions opt = new();
        opt.AddAdditionalOption(CapabilityType.AcceptInsecureCertificates, true);
        if (SetupHelper.RunInHeadlessMode)
        {
            opt.AddArguments("--window-size=1920, 1080");
            opt.AddArguments("--start-maximized");
            opt.AddArguments("--headless");
        }
        var driver = new FirefoxDriver(opt);
        if (!SetupHelper.RunInHeadlessMode)
        {
            driver.Manage().Window.Maximize();
        }

        return driver;
    }
}

