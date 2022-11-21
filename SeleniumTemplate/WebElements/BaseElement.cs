using OpenQA.Selenium;

namespace SeleniumTemplate.WebElements;

public abstract class BaseElement : IWrapsElement
{
    protected readonly IWebDriver Driver;
    public IWebElement WrappedElement { get; }

    public BaseElement(IWebDriver driver, IWebElement wrappedElement)
    {
        Driver = driver;
        WrappedElement = wrappedElement;
    }
    
    protected abstract void WaitTillReady();
}