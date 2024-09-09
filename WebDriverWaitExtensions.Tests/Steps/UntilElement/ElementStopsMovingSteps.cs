using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilElement;

[Binding]
public sealed class ElementStopsMovingSteps
{
    private readonly ScenarioContext _scenarioContext;

    public ElementStopsMovingSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"I use Wait\.UntilElement\(\)\.StopsMoving\(By\.Id\('([^,]*)'\)\)")]
    public void WhenIUseWaitUntilElementStopsMovingById(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilElement().StopsMoving(submitButton);
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilElement\(\)\.StopsMoving\(By\.Id\('([^,]*)'\), timeout\)")]
    public void WhenIUseWaitUntilElementStopsMovingByIdTimeout(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilElement().StopsMoving(submitButton, TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilElement\(\)\.StopsMoving\(By\.Id\('([^,]*)'\), out var condition\)")]
    public void WhenIUseWaitUntilElementStopsMovingByIdOutVarCondition(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilElement().StopsMoving(submitButton, out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilElement\(\)\.StopsMoving\(By\.Id\('([^,]*)'\), timeout, out var condition\)")]
    public void WhenIUseWaitUntilElementStopsMovingByIdTimeoutOutVarCondition(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilElement().StopsMoving(submitButton, TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }
}