using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilAlert;

[Binding]
public sealed class AlertIsSwitchedToSteps
{
    private readonly ScenarioContext _scenarioContext;

    public AlertIsSwitchedToSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"I use Wait\.UntilAlert\(\)\.IsSwitchedTo\(\)")]
    public void WhenIUseWaitUntilAlertIsSwitchedTo()
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var returnedAlert = wait.UntilAlert().IsSwitchedTo();
            _scenarioContext.Add(ScenarioContextKeys.ReturnedAlert, returnedAlert);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilAlert\(\)\.IsSwitchedTo\(timeout\)")]
    public void WhenIUseWaitUntilAlertIsSwitchedToTimeout()
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var returnedAlert = wait.UntilAlert().IsSwitchedTo(TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.ReturnedAlert, returnedAlert);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilAlert\(\)\.IsSwitchedTo\(out var condition\)")]
    public void WhenIUseWaitUntilAlertIsSwitchedToOutVarCondition()
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var returnedAlert = wait.UntilAlert().IsSwitchedTo(out var condition);
            _scenarioContext.Add(ScenarioContextKeys.ReturnedAlert, returnedAlert);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilAlert\(\)\.IsSwitchedTo\(timeout, out var condition\)")]
    public void WhenIUseWaitUntilAlertIsSwitchedToTimeoutOutVarCondition()
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var returnedAlert = wait.UntilAlert().IsSwitchedTo(TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.ReturnedAlert, returnedAlert);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }
}