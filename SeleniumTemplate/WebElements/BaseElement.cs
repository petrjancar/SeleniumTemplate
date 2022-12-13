using OpenQA.Selenium;
using SeleniumTemplate.Helpers;

namespace SeleniumTemplate.WebElements;

public abstract class BaseElement : IWrapsElement
{
    protected readonly IWebDriver Driver;
    public IWebElement WrappedElement { get; }

    public BaseElement(IWebDriver driver, By wrappedElementBy, int timeout)
    {
        Driver = driver;
        WrappedElement = WaitHelper.WaitForExistence(Driver, wrappedElementBy, timeout);
    }
    
    protected abstract void WaitTillReady();

    public bool HasClass(string className)
    {
        return ElementHelper.HasClass(WrappedElement, className);
    }
}