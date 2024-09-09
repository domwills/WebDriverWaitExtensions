using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilTextInElement;

[Binding]
public sealed class TextAttributeIsSteps
{
    private readonly ScenarioContext _scenarioContext;

    public TextAttributeIsSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.AttributeIs\(By\.Id\('([^,]*)'\), '([^,]*)', '([^,]*)'\)")]
    public void WhenIUseWaitUntilTextInElementAttributeIsById(string locator, string attribute, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilTextInElement().AttributeIs(submitButton, attribute, text);
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.AttributeIs\(By\.Id\('([^,]*)'\), '([^,]*)', '([^,]*)', timeout\)")]
    public void WhenIUseWaitUntilTextInElementAttributeIsByIdTimeout(string locator, string attribute, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilTextInElement().AttributeIs(submitButton, attribute, text, TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.AttributeIs\(By\.Id\('([^,]*)'\), '([^,]*)', '([^,]*)', out var condition\)")]
    public void WhenIUseWaitUntilTextInElementAttributeIsByIdOutVarCondition(string locator, string attribute, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilTextInElement().AttributeIs(submitButton, attribute, text, out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.AttributeIs\(By\.Id\('([^,]*)'\), '([^,]*)', '([^,]*)', timeout, out var condition\)")]
    public void WhenIUseWaitUntilTextInElementAttributeIsByIdTimeoutOutVarCondition(string locator, string attribute, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilTextInElement().AttributeIs(submitButton, attribute, text, TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }
}