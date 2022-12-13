using OpenQA.Selenium;
using SeleniumTemplate.Helpers;

namespace SeleniumTemplate.WebElements;

public class CheckBox : BaseElement
{
    public CheckBox(IWebDriver driver, By wrappedElementBy, int timeout = TimeoutHelper.MidTimeout) : base(driver, wrappedElementBy, timeout)
    {
        
    }

    protected override void WaitTillReady()
    {
        WaitHelper.WaitForClickable(Driver, WrappedElement, TimeoutHelper.MidTimeout);
    }

    public bool IsChecked()
    {
        return WrappedElement.Selected;
    }

    public void Check()
    {
        WaitTillReady();
        if (IsChecked())
        {
            return;
        }
        WrappedElement.Click();
    }
    
    public void Uncheck()
    {
        WaitTillReady();
        if (IsChecked())
        {
            WrappedElement.Click();
        }
    }
}