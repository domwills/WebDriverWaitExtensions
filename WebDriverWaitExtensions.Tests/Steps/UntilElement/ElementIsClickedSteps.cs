using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilElement;

[Binding]
public sealed class ElementIsClickedSteps
{
    private readonly ScenarioContext _scenarioContext;

    public ElementIsClickedSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"the WebElement reference is invalid when clicked")]
    public void GivenTheWebElementReferenceIsInvalidWhenClicked()
    {
        var mockDriver = MockSetup.GetDriver(_scenarioContext);
        var mockElement = MockSetup.GetWebElement(_scenarioContext);

        mockElement.Setup(e => e.Click())
            .Throws(new StaleElementReferenceException());

        mockDriver.Setup(d => d.FindElement(By.Id("id")))
            .Returns(mockElement.Object);

        _scenarioContext.AddOrUpdate(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [When(@"I use Wait\.UntilElement\(\)\.IsClicked\(By\.Id\('([^,]*)'\)\)")]
    public void WhenIUseWaitUntilElementIsClickedById(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilElement().IsClicked(submitButton);
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilElement\(\)\.IsClicked\(By\.Id\('([^,]*)'\), out var condition\)")]
    public void WhenIUseWaitUntilElementIsClickedByIdOutVarCondition(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilElement().IsClicked(submitButton, out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch(Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilElement\(\)\.IsClicked\(By\.Id\('([^,]*)'\), timeout\)")]
    public void WhenIUseWaitUntilElementIsClickedByIdTimeout(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilElement().IsClicked(submitButton, TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilElement\(\)\.IsClicked\(By\.Id\('([^,]*)'\), timeout, out var condition\)")]
    public void WhenIUseWaitUntilElementIsClickedByIdTimeoutOutVarCondition(string locator)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            var submitButton = By.Id(locator);
            wait.UntilElement().IsClicked(submitButton, TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch(Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }
}