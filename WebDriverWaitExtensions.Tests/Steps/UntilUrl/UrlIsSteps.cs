using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilUrl;

[Binding]
public sealed class UrlIsSteps
{
    private readonly ScenarioContext _scenarioContext;

    public UrlIsSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"I use Wait\.UntilUrl\.Is\('([^,]*)'\)")]
    public void WhenIUseWaitUntilUrlIs(string url)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            wait.UntilUrl().Is(url);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilUrl\.Is\('([^,]*)', timeout\)")]
    public void WhenIUseWaitUntilUrlIsTimeout(string url)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            wait.UntilUrl().Is(url, TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilUrl\.Is\('([^,]*)', out var condition\)")]
    public void WhenIUseWaitUntilUrlIsOutVarCondition(string url)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            wait.UntilUrl().Is(url, out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilUrl\.Is\('([^,]*)', timeout, out var condition\)")]
    public void WhenIUseWaitUntilUrlIsTimeoutOutVarCondition(string url)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            wait.UntilUrl().Is(url, TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }
}