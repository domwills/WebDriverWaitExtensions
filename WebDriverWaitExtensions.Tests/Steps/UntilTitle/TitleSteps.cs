using Moq;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilTitle;

[Binding]
public sealed class TitleSteps
{
    private readonly ScenarioContext _scenarioContext;

    public TitleSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"the page title changes to be '(.*)'")]
    public void GivenThePageTitleChangesToBe(string title)
    {
        var mockDriver = new Mock<IWebDriver>();

        mockDriver.SetupSequence(d => d.Title)
            .Returns("invalid")
            .Returns(title);

        _scenarioContext.Add(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Given(@"the page title is '(.*)'")]
    public void GivenThePageTitleIs(string title)
    {
        var mockDriver = new Mock<IWebDriver>();

        mockDriver.Setup(d => d.Title)
            .Returns(title);

        _scenarioContext.Add(ScenarioContextKeys.MockDriver, mockDriver);
    }
}