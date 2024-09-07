using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilTextInElement;

[Binding]
public sealed class TextCssValueDoesNotContainSteps
{
    private readonly ScenarioContext _scenarioContext;

    public TextCssValueDoesNotContainSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.CssValueDoesNotContain\(By\.Id\('([^,]*)'\), '([^,]*)', '([^,]*)'\)")]
    public void WhenIUseWaitUntilTextInElementCssValueDoesNotContainById(string locator, string cssValue, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilTextInElement().CssValueDoesNotContain(submitButton, cssValue, text);
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.CssValueDoesNotContain\(By\.Id\('([^,]*)'\), '([^,]*)', '([^,]*)', timeout\)")]
    public void WhenIUseWaitUntilTextInElementCssValueDoesNotContainByIdTimeout(string locator, string cssValue, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilTextInElement().CssValueDoesNotContain(submitButton, cssValue, text, TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.CssValueDoesNotContain\(By\.Id\('([^,]*)'\), '([^,]*)', '([^,]*)', out var condition\)")]
    public void WhenIUseWaitUntilTextInElementCssValueDoesNotContainByIdOutVarCondition(string locator, string cssValue, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilTextInElement().CssValueDoesNotContain(submitButton, cssValue, text, out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.CssValueDoesNotContain\(By\.Id\('(.*)'\), '(.*)', '(.*)', timeout, out var condition\)")]
    public void WhenIUseWaitUntilTextInElementCssValueDoesNotContainByIdTimeoutOutVarCondition(string locator, string cssValue, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilTextInElement().CssValueDoesNotContain(submitButton, cssValue, text, TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }
}