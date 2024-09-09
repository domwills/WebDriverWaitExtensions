using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilTextInElement;

[Binding]
public sealed class TextCssValueContainsSteps
{
    private readonly ScenarioContext _scenarioContext;

    public TextCssValueContainsSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.CssValueContains\(By\.Id\('([^,]*)'\), '([^,]*)', '([^,]*)'\)")]
    public void WhenIUseWaitUntilTextInElementCssValueContainsById(string locator, string cssValue, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilTextInElement().CssValueContains(submitButton, cssValue, text);
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.CssValueContains\(By\.Id\('([^,]*)'\), '([^,]*)', '([^,]*)', timeout\)")]
    public void WhenIUseWaitUntilTextInElementCssValueContainsByIdTimeout(string locator, string cssValue, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilTextInElement().CssValueContains(submitButton, cssValue, text, TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.CssValueContains\(By\.Id\('([^,]*)'\), '([^,]*)', '([^,]*)', out var condition\)")]
    public void WhenIUseWaitUntilTextInElementCssValueContainsByIdOutVarCondition(string locator, string cssValue, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilTextInElement().CssValueContains(submitButton, cssValue, text, out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.CssValueContains\(By\.Id\('([^,]*)'\), '([^,]*)', '([^,]*)', timeout, out var condition\)")]
    public void WhenIUseWaitUntilTextInElementCssValueContainsByIdTimeoutOutVarCondition(string locator, string cssValue, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilTextInElement().CssValueContains(submitButton, cssValue, text, TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }
}