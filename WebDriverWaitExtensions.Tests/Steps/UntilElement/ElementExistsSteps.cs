using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilElement;

[Binding]
public sealed class ElementExistsSteps
{
    private readonly ScenarioContext _scenarioContext;

    public ElementExistsSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"I use Wait\.UntilElement\(\)\.Exists\(By\.Id\('([^,]*)'\)\)")]
    public void WhenIUseWaitUntilElementExistsById(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilElement().Exists(submitButton);
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilElement\(\)\.Exists\(By\.Id\('([^,]*)'\), timeout\)")]
    public void WhenIUseWaitUntilElementExistsByIdTimeout(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilElement().Exists(submitButton, TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilElement\(\)\.Exists\(By\.Id\('([^,]*)'\), out var condition\)")]
    public void WhenIUseWaitUntilElementExistsByIdOutVarCondition(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilElement().Exists(submitButton, out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch(Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilElement\(\)\.Exists\(By\.Id\('([^,]*)'\), timeout, out var condition\)")]
    public void WhenIUseWaitUntilElementExistsByIdTimeoutOutVarCondition(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilElement().Exists(submitButton, TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch(Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }
}