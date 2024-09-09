using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilFrame;

[Binding]
public sealed class FrameIsSwitchedToSteps
{
    private readonly ScenarioContext _scenarioContext;

    public FrameIsSwitchedToSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"I use Wait\.UntilFrame\(\)\.IsSwitchedTo\('([^,]*)'\)")]
    public void WhenIUseWaitUntilFrameIsSwitchedTo(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var returnDriver = wait.UntilFrame().IsSwitchedTo(locator);
            _scenarioContext.Add(ScenarioContextKeys.ReturnedDriver, returnDriver);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilFrame\(\)\.IsSwitchedTo\('([^,]*)', timeout\)")]
    public void WhenIUseWaitUntilFrameIsSwitchedToTimeout(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var returnDriver = wait.UntilFrame().IsSwitchedTo(locator, TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.ReturnedDriver, returnDriver);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilFrame\(\)\.IsSwitchedTo\(By\.Id\('([^,]*)'\)\)")]
    public void WhenIUseWaitUntilFrameIsSwitchedToById(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnDriver = wait.UntilFrame().IsSwitchedTo(submitButton);
            _scenarioContext.Add(ScenarioContextKeys.ReturnedDriver, returnDriver);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilFrame\(\)\.IsSwitchedTo\(By\.Id\('([^,]*)'\), timeout\)")]
    public void WhenIUseWaitUntilFrameIsSwitchedToByIdTimeout(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            var returnDriver = wait.UntilFrame().IsSwitchedTo(submitButton, TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.ReturnedDriver, returnDriver);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilFrame\(\)\.IsSwitchedTo\(By\.Id\('([^,]*)'\), out var condition\)")]
    public void WhenIUseWaitUntilFrameIsSwitchedToByIdOutVarCondition(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilFrame().IsSwitchedTo(submitButton, out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilFrame\(\)\.IsSwitchedTo\(By\.Id\('([^,]*)'\), timeout, out var condition\)")]
    public void WhenIUseWaitUntilFrameIsSwitchedToByIdTimeoutOutVarCondition(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilFrame().IsSwitchedTo(submitButton, TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilFrame\(\)\.IsSwitchedTo\('([^,]*)', out var condition\)")]
    public void WhenIUseWaitUntilFrameIsSwitchedToOutVarCondition(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            wait.UntilFrame().IsSwitchedTo(locator, out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilFrame\(\)\.IsSwitchedTo\('(.*)', timeout, out var condition\)")]
    public void WhenIUseWaitUntilFrameIsSwitchedToTimeoutOutVarCondition(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            wait.UntilFrame().IsSwitchedTo(locator, TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }
}