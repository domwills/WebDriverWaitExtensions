using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilTextInElement;

[Binding]
public sealed class TextAttributeDoesNotContainSteps
{
    private readonly ScenarioContext _scenarioContext;

    public TextAttributeDoesNotContainSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.AttributeDoesNotContain\(By\.Id\('([^,]*)'\), '([^,]*)', '([^,]*)'\)")]
    public void WhenIUseWaitUntilTextInElementAttributeDoesNotContainById(string locator, string attribute, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id("id");
            var returnedElement = wait.UntilTextInElement().AttributeDoesNotContain(submitButton, attribute, text);
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.AttributeDoesNotContain\(By\.Id\('([^,]*)'\), '([^,]*)', '([^,]*)', timeout\)")]
    public void WhenIUseWaitUntilTextInElementAttributeDoesNotContainByIdTimeout(string locator, string attribute, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id("id");
            var returnedElement = wait.UntilTextInElement().AttributeDoesNotContain(submitButton, attribute, text, TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.AttributeDoesNotContain\(By\.Id\('([^,]*)'\), '([^,]*)', '([^,]*)', out var condition\)")]
    public void WhenIUseWaitUntilTextInElementAttributeDoesNotContainByIdOutVarCondition(string locator, string attribute, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id("id");
            wait.UntilTextInElement().AttributeDoesNotContain(submitButton, attribute, text, out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTextInElement\(\)\.AttributeDoesNotContain\(By\.Id\('([^,]*)'\), '([^,]*)', '([^,]*)', timeout, out var condition\)")]
    public void WhenIUseWaitUntilTextInElementAttributeDoesNotContainByIdTimeoutOutVarCondition(string locator, string attribute, string text)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id("id");
            wait.UntilTextInElement().AttributeDoesNotContain(submitButton, attribute, text, TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }
}