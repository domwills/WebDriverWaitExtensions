using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilElement;

[Binding]
public sealed class ElementIsSelectedSteps
{
    private readonly ScenarioContext _scenarioContext;

    public ElementIsSelectedSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"I use Wait\.UntilElement\(\)\.IsSelected\(By\.Id\('([^,]*)'\)\)")]
    public void WhenIUseWaitUntilElementIsSelectedById(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilElement().IsSelected(submitButton);
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilElement\(\)\.IsSelected\(By\.Id\('([^,]*)'\), timeout\)")]
    public void WhenIUseWaitUntilElementIsSelectedByIdTimeout(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilElement().IsSelected(submitButton, TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilElement\(\)\.IsSelected\(By\.Id\('([^,]*)'\), out var condition\)")]
    public void WhenIUseWaitUntilElementIsSelectedByIdOutVarCondition(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilElement().IsSelected(submitButton, out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilElement\(\)\.IsSelected\(By\.Id\('([^,]*)'\), timeout, out var condition\)")]
    public void WhenIUseWaitUntilElementIsSelectedByIdTimeoutOutVarCondition(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilElement().IsSelected(submitButton, TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }
}