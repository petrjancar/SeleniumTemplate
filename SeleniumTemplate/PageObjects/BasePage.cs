using OpenQA.Selenium;

namespace SeleniumTemplate.PageObjects;

public abstract class BasePage
{
    protected IWebDriver Driver;
    public string Url;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
    }
    
    public void Navigate()
    {
        Driver.Navigate().GoToUrl(Url);
    }      
}

