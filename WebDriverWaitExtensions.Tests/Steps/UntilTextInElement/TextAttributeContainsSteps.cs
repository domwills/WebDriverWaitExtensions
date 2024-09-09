using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilTextInElement;

[Binding]
public sealed class TextAttributeContainsSteps
{
    private readonly ScenarioContext _scenarioContext;

    public TextAttributeContainsSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.AttributeContains\(By\.Id\('([^,]*)'\), '([^,]*)', '([^,]*)'\)")]
    public void WhenIUseWaitUntilTextInElementAttributeContainsById(string locator, string attribute, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilTextInElement().AttributeContains(submitButton, attribute, text);
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.AttributeContains\(By\.Id\('([^,]*)'\), '([^,]*)', '([^,]*)', timeout\)")]
    public void WhenIUseWaitUntilTextInElementAttributeContainsByIdTimeout(string locator, string attribute, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilTextInElement().AttributeContains(submitButton, attribute, text, TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.AttributeContains\(By\.Id\('([^,]*)'\), '([^,]*)', '([^,]*)', out var condition\)")]
    public void WhenIUseWaitUntilTextInElementAttributeContainsByIdOutVarCondition(string locator, string attribute, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilTextInElement().AttributeContains(submitButton, attribute, text, out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.AttributeContains\(By\.Id\('([^,]*)'\), '([^,]*)', '([^,]*)', timeout, out var condition\)")]
    public void WhenIUseWaitUntilTextInElementAttributeContainsByIdTimeoutOutVarCondition(string locator, string attribute, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilTextInElement().AttributeContains(submitButton, attribute, text, TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }
}