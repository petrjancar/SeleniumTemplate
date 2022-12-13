using OpenQA.Selenium;

namespace SeleniumTemplate.PageFragments;

public abstract class BaseFragment
{
    protected IWebDriver Driver;     

    protected BaseFragment(IWebDriver driver)
    {
        Driver = driver;
    }
}

