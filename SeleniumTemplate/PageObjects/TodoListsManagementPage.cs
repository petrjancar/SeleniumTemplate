using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using SeleniumTemplate.Helpers;

namespace SeleniumTemplate.PageObjects;

public class TodoListsManagementPage : BasePage
{
    private By NewTodoListInputBy = By.ClassName("new-todo-list");
    
    private class TodoListsTableRowFragment
    {
        private IWebDriver Driver;
        private int Nth;
        private string _listName = null;
        public bool Exists => ThisTableRow != null;
        private readonly By TableBy = By.CssSelector(".todo-list-list");
        private readonly By TableRowBy = By.CssSelector(".todo-list-list li");
        private IWebElement ThisTableRow => _listName != null ? Driver.FindElements(TableRowBy)
            .Where(p => p.FindElement(By.CssSelector(".view label")).Text == _listName).FirstOrDefault() 
            : Driver.FindElements(TableRowBy)[Nth];

        private By UseButtonBy => By.CssSelector(".view a");

        public TodoListsTableRowFragment(IWebDriver driver, int nth)
        {
            Driver = driver;
            Nth = nth;
            WaitHelper.WaitForVisible(Driver, TableBy, TimeoutHelper.MidTimeout);
        }

        public TodoListsTableRowFragment(IWebDriver driver, string listName)
        {
            Driver = driver;
            _listName = listName;
            WaitHelper.WaitForVisible(Driver, TableBy, TimeoutHelper.MidTimeout);
        }

        public void ClickUseButton()
        {
            var button = WaitHelper.WaitForClickable(Driver, UseButtonBy, TimeoutHelper.MidTimeout);
            button.Click();
        }
    }

    public TodoListsManagementPage(IWebDriver driver) : base(driver)
    {
        Url = SetupHelper.BaseUrl + "todolists.html/";
    }

    public void CreateNewTodoList(string todoListName)
    {
        var input = WaitHelper.WaitForClickable(Driver, NewTodoListInputBy, TimeoutHelper.MidTimeout);
        input.SendKeys(todoListName);
        input.SendKeys(Keys.Enter);
    }

    public bool TodoListExists(string todoListName)
    {
        var tableRowFragment = new TodoListsTableRowFragment(Driver, todoListName);
        return tableRowFragment.Exists;
    }
}