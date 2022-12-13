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
        // Arrange
        var todoListName = TodoListName.GenerateName();

        // Act
        var todoMainPage = new TodoMainPage(Driver);
        todoMainPage.Navigate();
        todoMainPage.ClickManageTodoListsLink();
        var todoListsManagementPage = new TodoListsManagementPage(Driver);        
        todoListsManagementPage.CreateNewTodoList(todoListName);

        // Assert
        Assert.That(todoListsManagementPage.TodoListExists(todoListName), Is.True);
    }
}

// Run with custom .runsettings
// ----------------------------
// 1) cd SeleniumTemplate/
// 2) dotnet test SeleniumTemplate.csproj -s RunSettings/Default.runsettings