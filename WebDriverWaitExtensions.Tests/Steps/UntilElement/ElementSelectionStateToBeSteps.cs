using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilElement;

[Binding]
public sealed class ElementSelectionStateToBeSteps
{
    private readonly ScenarioContext _scenarioContext;

    public ElementSelectionStateToBeSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"I use Wait\.UntilElement\(\)\.SelectedStateIs\(By\.Id\('([^,]*)'\), '([^,]*)'\)")]
    public void WhenIUseWaitUntilElementSelectedStateIsById(string locator, bool isSelected)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilElement().SelectedStateIs(submitButton, isSelected);
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilElement\(\)\.SelectedStateIs\(By\.Id\('([^,]*)'\), '([^,]*)', timeout\)")]
    public void WhenIUseWaitUntilElementSelectedStateIsByIdTimeout(string locator, bool isSelected)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnedElement = wait.UntilElement().SelectedStateIs(submitButton, isSelected, TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.ReturnedElement, returnedElement);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilElement\(\)\.SelectedStateIs\(By\.Id\('([^,]*)'\), '([^,]*)', out var condition\)")]
    public void WhenIUseWaitUntilElementSelectionStateToBeConditionById(string locator, bool isSelected)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilElement().SelectedStateIs(submitButton, isSelected, out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilElement\(\)\.SelectedStateIs\(By\.Id\('([^,]*)'\), '([^,]*)', timeout, out var condition\)")]
    public void WhenIUseWaitUntilElementSelectedStateIsByIdTimeoutOutVarCondition(string locator, bool isSelected)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilElement().SelectedStateIs(submitButton, isSelected, TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }
}