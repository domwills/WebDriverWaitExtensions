using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilUrl;

[Binding]
public sealed class UrlContainsSteps
{
    private readonly ScenarioContext _scenarioContext;

    public UrlContainsSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"I use Wait\.UntilUrl\.Contains\('([^,]*)'\)")]
    public void WhenIUseWaitUntilUrlContains(string fraction)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            wait.UntilUrl().Contains(fraction);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilUrl\.Contains\('([^,]*)', timeout\)")]
    public void WhenIUseWaitUntilUrlContainsTimeout(string fraction)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            wait.UntilUrl().Contains(fraction, TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilUrl\.Contains\('([^,]*)', out var condition\)")]
    public void WhenIUseWaitUntilUrlContainsOutVarCondition(string fraction)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            wait.UntilUrl().Contains(fraction, out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilUrl\.Contains\('([^,]*)', timeout, out var condition\)")]
    public void WhenIUseWaitUntilUrlContainsTimeoutOutVarCondition(string fraction)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            wait.UntilUrl().Contains(fraction, TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }
}