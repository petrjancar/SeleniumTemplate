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

    public bool ElementHaveClass(IWebElement element, string classStr)
    {
        string classes = element.GetAttribute("class");
        foreach (string c in classes.Split(" "))
        {
            if (c.Equals(classStr))
            {
                return true;
            }
        }

        return false;
    }    
}

