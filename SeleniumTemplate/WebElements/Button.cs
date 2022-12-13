using OpenQA.Selenium;
using SeleniumTemplate.Helpers;

namespace SeleniumTemplate.WebElements;

public class Button : BaseElement
{
    public Button(IWebDriver driver, By wrappedElementBy, int timeout=TimeoutHelper.MidTimeout) : base(driver, wrappedElementBy, timeout)
    {
        
    }
    
    protected override void WaitTillReady()
    {
        WaitHelper.WaitForClickable(Driver, WrappedElement, TimeoutHelper.MidTimeout);
    }

    public void Click()
    {
        WaitTillReady();
        WrappedElement.Click();
    }
}