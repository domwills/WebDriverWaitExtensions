using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilElement;

[Binding]
public sealed class ElementDoesNotExistSteps
{
    private readonly ScenarioContext _scenarioContext;

    public ElementDoesNotExistSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"I use Wait\.UntilElement\(\)\.DoesNotExist\(By\.Id\('([^,]*)'\)\)")]
    public void WhenIUseWaitUntilElementDoesNotExistById(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilElement().DoesNotExist(submitButton);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilElement\(\)\.DoesNotExist\(By\.Id\('([^,]*)'\), timeout\)")]
    public void WhenIUseWaitUntilElementDoesNotExistByIdTimeout(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilElement().DoesNotExist(submitButton, TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilElement\(\)\.DoesNotExist\(By\.Id\('([^,]*)'\), out var condition\)")]
    public void WhenIUseWaitUntilElementDoesNotExistByIdOutVarCondition(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilElement().DoesNotExist(submitButton, out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilElement\(\)\.DoesNotExist\(By\.Id\('([^,]*)'\), timeout, out var condition\)")]
    public void WhenIUseWaitUntilElementDoesNotExistByIdTimeoutOutVarCondition(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilElement().DoesNotExist(submitButton, TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }
}