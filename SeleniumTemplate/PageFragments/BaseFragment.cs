using OpenQA.Selenium;

namespace SeleniumTemplate.PageFragments;

public abstract class BaseFragment
{
    protected IWebDriver Driver;     

    protected BaseFragment(IWebDriver driver)
    {
        Driver = driver;
    }

    public bool ElementHaveClass(IWebElement element, string classStr)
    {
        string classes = element.GetAttribute("class");
        foreach (string c in classes.Split(" "))
        {
            if (string.Compare(c, classStr) == 0)
            {
                return true;
            }
        }

        return false;
    }
}

