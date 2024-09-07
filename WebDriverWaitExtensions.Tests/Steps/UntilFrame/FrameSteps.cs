using Moq;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilFrame;

[Binding]
public sealed class FrameSteps
{
    private readonly ScenarioContext _scenarioContext;

    public FrameSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"the frame is available when found using a string")]
    public void GivenTheFrameIsAvailableWhenFoundUsingAString()
    {
        var mockDriver = new Mock<IWebDriver>();

        mockDriver.SetupSequence(d => d.SwitchTo().Frame("id"))
            .Throws(new NoSuchFrameException())
            .Returns(mockDriver.Object);

        _scenarioContext.Add(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Given(@"the frame is not available when found using a string")]
    public void GivenTheFrameIsNotAvailableWhenFoundUsingAString()
    {
        var mockDriver = new Mock<IWebDriver>();

        mockDriver.Setup(d => d.SwitchTo().Frame("id"))
            .Throws(new NoSuchFrameException());

        _scenarioContext.Add(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Given(@"the frame is available when found using a WebElement")]
    public void GivenTheFrameIsAvailableWhenFoundUsingAWebElement()
    {
        var mockDriver = new Mock<IWebDriver>();
        var mockElement = new Mock<IWebElement>();

        mockDriver.Setup(d => d.FindElement(By.Id("id")))
            .Returns(mockElement.Object);

        mockDriver.SetupSequence(d => d.SwitchTo().Frame(mockElement.Object))
            .Throws(new NoSuchFrameException())
            .Returns(mockDriver.Object);

        _scenarioContext.Add(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Given(@"the frame is not available when found using a WebElement")]
    public void GivenTheFrameIsNotAvailableWhenFoundUsingAWebElement()
    {
        var mockDriver = new Mock<IWebDriver>();
        var mockElement = new Mock<IWebElement>();

        mockDriver.Setup(d => d.FindElement(By.Id("id")))
            .Returns(mockElement.Object);

        mockDriver.Setup(d => d.SwitchTo().Frame(mockElement.Object))
            .Throws(new NoSuchFrameException());

        _scenarioContext.Add(ScenarioContextKeys.MockDriver, mockDriver);
    }
}