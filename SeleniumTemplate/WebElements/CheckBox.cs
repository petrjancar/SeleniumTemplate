using OpenQA.Selenium;

namespace SeleniumTemplate.WebElements;

public class CheckBox : IWrapsElement
{
    public IWebElement WrappedElement { get; }
    
    public CheckBox(IWebElement wrappedElement)
    {
        WrappedElement = wrappedElement;
    }

    public bool IsChecked()
    {
        return WrappedElement.Selected;
    }

    public void Check()
    {
        if (IsChecked())
        {
            return;
        }
        WrappedElement.Click();
    }
    
    public void Uncheck()
    {
        if (IsChecked())
        {
            WrappedElement.Click();
        }
    }
}