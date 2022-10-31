using SeleniumTemplate.Data;
using SeleniumTemplate.PageObjects;

namespace SeleniumTemplate.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TodoTests : BaseTests
{
    [Test]
    public void CreateTodoListTest()
    {
        var todoMainPage = new TodoMainPage(Driver);
        todoMainPage.Navigate();
        todoMainPage.ClickManageTodoListsLink();
        var todoListsManagementPage = new TodoListsManagementPage(Driver);
        var todoListName = TodoListName.GenerateName();
        todoListsManagementPage.CreateNewTodoList(todoListName);
        Assert.That(todoListsManagementPage.TodoListExists(todoListName), Is.True);
    }
}

// cd SeleniumTemplate/
// dotnet test SeleniumTemplate.csproj -s RunSettings/Default.runsettings