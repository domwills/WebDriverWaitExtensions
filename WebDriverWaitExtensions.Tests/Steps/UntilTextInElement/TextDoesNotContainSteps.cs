using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilTextInElement;

[Binding]
public sealed class TextDoesNotContainSteps
{
    private readonly ScenarioContext _scenarioContext;

    public TextDoesNotContainSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.DoesNotContain\(By\.Id\('([^,]*)'\)\, '([^,]*)'\)")]
    public void WhenIUseWaitUntilTextInElementDoesNotContainById(string locator, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilTextInElement().DoesNotContain(submitButton, text);
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.DoesNotContain\(By\.Id\('([^,]*)'\), '([^,]*)', timeout\)")]
    public void WhenIUseWaitUntilTextInElementDoesNotContainByIdTimeout(string locator, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilTextInElement().DoesNotContain(submitButton, text, TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.DoesNotContain\(By\.Id\('([^,]*)'\), '([^,]*)', out var condition\)")]
    public void WhenIUseWaitUntilTextInElementDoesNotContainByIdOutVarCondition(string locator, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilTextInElement().DoesNotContain(submitButton, text, out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.DoesNotContain\(By\.Id\('([^,]*)'\), '([^,]*)', timeout, out var condition\)")]
    public void WhenIUseWaitUntilTextInElementDoesNotContainByIdTimeoutOutVarCondition(string locator, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilTextInElement().DoesNotContain(submitButton, text, TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }
}