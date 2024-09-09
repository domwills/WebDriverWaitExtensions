using Moq;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilUrl;

[Binding]
public sealed class UrlSteps
{
    private readonly ScenarioContext _scenarioContext;

    public UrlSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"the current URL changes to be '(.*)'")]
    public void GivenTheCurrentUrlChangesToBe(string url)
    {
        var mockDriver = new Mock<IWebDriver>();

        mockDriver.SetupSequence(d => d.Url)
            .Returns("invalid")
            .Returns(url);

        _scenarioContext.Add(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Given(@"the current URL is '(.*)'")]
    public void GivenTheCurrentUrlIs(string url)
    {
        var mockDriver = new Mock<IWebDriver>();

        mockDriver.Setup(d => d.Url)
            .Returns(url);

        _scenarioContext.Add(ScenarioContextKeys.MockDriver, mockDriver);
    }
}