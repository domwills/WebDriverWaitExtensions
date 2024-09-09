using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilTextInElement;

[Binding]
public sealed class TextValueDoesNotContainSteps
{
    private readonly ScenarioContext _scenarioContext;

    public TextValueDoesNotContainSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.ValueDoesNotContain\(By\.Id\('([^,]*)'\), '([^,]*)'\)")]
    public void WhenIUseWaitUntilTextInElementValueDoesNotContainById(string locator, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilTextInElement().ValueDoesNotContain(submitButton, text);
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.ValueDoesNotContain\(By\.Id\('([^,]*)'\), '([^,]*)', timeout\)")]
    public void WhenIUseWaitUntilTextInElementValueDoesNotContainByIdTimeout(string locator, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilTextInElement().ValueDoesNotContain(submitButton, text, TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.ValueDoesNotContain\(By\.Id\('([^,]*)'\), '([^,]*)', out var condition\)")]
    public void WhenIUseWaitUntilTextInElementValueDoesNotContainByIdOutVarCondition(string locator, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilTextInElement().ValueDoesNotContain(submitButton, text, out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.ValueDoesNotContain\(By\.Id\('([^,]*)'\), '([^,]*)', timeout, out var condition\)")]
    public void WhenIUseWaitUntilTextInElementValueDoesNotContainByIdTimeoutOutVarCondition(string locator, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilTextInElement().ValueDoesNotContain(submitButton, text, TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }
}