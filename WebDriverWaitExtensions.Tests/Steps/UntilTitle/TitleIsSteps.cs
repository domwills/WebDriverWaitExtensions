using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilTitle;

[Binding]
public sealed class TitleIsSteps
{
    private readonly ScenarioContext _scenarioContext;

    public TitleIsSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"I use Wait\.UntilTitle\.Is\('([^,]*)'\)")]
    public void WhenIUseWaitUntilTitleIs(string title)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            wait.UntilTitle().Is(title);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTitle\.Is\('([^,]*)', timeout\)")]
    public void WhenIUseWaitUntilTitleIsTimeout(string title)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            wait.UntilTitle().Is(title, TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTitle\.Is\('([^,]*)', out var condition\)")]
    public void WhenIUseWaitUntilTitleIsOutVarCondition(string title)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            wait.UntilTitle().Is(title, out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilTitle\.Is\('([^,]*)', timeout, out var condition\)")]
    public void WhenIUseWaitUntilTitleIsTimeoutOutVarCondition(string title)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            wait.UntilTitle().Is(title, TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }
}